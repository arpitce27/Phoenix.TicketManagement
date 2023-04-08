using Microsoft.EntityFrameworkCore;
using Phoenix.TicketManagement.Application;
using Phoenix.TicketManagement.Infrastructure;
using Phoenix.TicketManagement.Persistence;

namespace Phoenix.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigurServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceService(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("Open", b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }

        public static WebApplication ConfigurPipeline(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Open");

            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<PhoenixTicketDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureCreatedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
