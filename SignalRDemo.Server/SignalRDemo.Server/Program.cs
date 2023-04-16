using SignalRDemo.Server;
using SignalRDemo.Server.Api.Hubs;
using SignalRDemo.Server.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguredIdentity(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseMiddleware<ErrorHandler>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<DeclarationsHub>("hubs/declarations");

app.Run();