using Phoenix.TicketManagement.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigurServices().ConfigurPipeline();

app.Run();
