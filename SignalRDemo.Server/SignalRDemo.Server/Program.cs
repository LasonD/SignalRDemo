using SignalRDemo.Server;
using SignalRDemo.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguredIdentity(builder.Configuration);

var app = builder.Build();

app.MapControllers();

app.MapHub<DeclarationsHub>("hubs/declarations");

app.Run();