using Phoenix.TicketManagement.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigurServices().ConfigurPipeline();

await app.ResetDatabaseAsync();

app.Run();
