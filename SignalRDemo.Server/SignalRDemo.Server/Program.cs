using SignalRDemo.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapControllers();

app.MapHub<DeclarationsHub>("hubs/declarations");

app.Run();


