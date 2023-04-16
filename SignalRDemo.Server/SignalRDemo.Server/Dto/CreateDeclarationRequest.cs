namespace SignalRDemo.Server.Dto;

public class CreateDeclarationRequest
{
    public string DeclarantId { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Jurisdiction { get; set; } = null!;
}