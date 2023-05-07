using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using SignalRDemo.ConsoleClient;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Console.Write("Enter access token: ");
var token = Console.ReadLine();

var connection = new HubConnectionBuilder()
    .WithUrl(configuration["HubUrl"]!, options =>
    {
        options.AccessTokenProvider = () => Task.FromResult(token);
        options.Transports = HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents | HttpTransportType.LongPolling;
    })
    .Build();

connection.On<DeclarationDto>("DeclarationCreated", (declaration) =>
{
    PrintDeclaration("Declaration created: ", ConsoleColor.Green, declaration);
});

connection.On<DeclarationDto>("DeclarationUpdated", (declaration) =>
{
    PrintDeclaration("Declaration updated: ", ConsoleColor.Yellow, declaration);
});

connection.On<string>("DeclarationDeleted", (declarationId) =>
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Declaration deleted: {declarationId}");
    Console.ResetColor();
});

connection.Closed += _ =>
{
    Console.WriteLine("Connection is closed.");
    return Task.CompletedTask;
};

await connection.StartAsync();
Console.ReadKey();
await connection.StopAsync();

static void PrintDeclaration(string caption, ConsoleColor color, DeclarationDto declaration)
{
    Console.ForegroundColor = color;

    Console.WriteLine($"\t\t{caption}");
    Console.WriteLine(declaration);

    Console.ResetColor();
}
