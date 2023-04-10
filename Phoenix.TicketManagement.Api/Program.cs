using Phoenix.TicketManagement.Api;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Phoenix TM API Starting...");


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
     .WriteTo.Console()
     .ReadFrom.Configuration(context.Configuration));

var app = builder.ConfigurServices().ConfigurPipeline();

app.UseSerilogRequestLogging();

await app.ResetDatabaseAsync();

app.Run();
