using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.TicketManagement.Application.Contracts.Infrastructure;
using Phoenix.TicketManagement.Application.Models.Mail;
using Phoenix.TicketManagement.Infrastructure.FileExport;
using Phoenix.TicketManagement.Infrastructure.Mail;

namespace Phoenix.TicketManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
