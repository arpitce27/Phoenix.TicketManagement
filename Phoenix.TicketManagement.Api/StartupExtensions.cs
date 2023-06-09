﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Phoenix.TicketManagement.Api.Middleware;
using Phoenix.TicketManagement.Api.Services;
using Phoenix.TicketManagement.Api.Utility;
using Phoenix.TicketManagement.Application;
using Phoenix.TicketManagement.Application.Contracts;
using Phoenix.TicketManagement.Identity;
using Phoenix.TicketManagement.Infrastructure;
using Phoenix.TicketManagement.Persistence;

namespace Phoenix.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigurServices(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            builder.Services.AddControllers();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("Open", b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }

        public static WebApplication ConfigurPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Phoenix Ticket Management APIs");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseCustomExceptionHandler();

            app.UseCors("Open");

            app.UseAuthorization();

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

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization using token scheme. \r\n\r\n" +
                        "Enter Bearer [space] and then token in the input below. \r\n\r\n" +
                        "For Example: Bearer 23hk32hk3jh231jhkkj",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { 
                        new OpenApiSecurityScheme
                        { 
                            Reference = new OpenApiReference
                            { 
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Phoenix Ticket Management APIs"
                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }
    }
}
