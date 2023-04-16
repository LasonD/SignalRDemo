namespace SignalRDemo.Server.Dto;

public class UpdateDeclarationRequest
{
    public string Id { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Jurisdiction { get; set; } = null!;
}