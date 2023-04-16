namespace SignalRDemo.Server.Models;

public class Declaration
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public Jurisdiction Jurisdiction { get; set; } = null!;
}