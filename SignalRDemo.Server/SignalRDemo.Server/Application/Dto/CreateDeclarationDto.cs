namespace SignalRDemo.Server.Application.Dto;

public class CreateDeclarationDto
{
    public string DeclarantId { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Jurisdiction { get; set; } = null!;
}