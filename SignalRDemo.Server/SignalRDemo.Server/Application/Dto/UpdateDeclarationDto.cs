namespace SignalRDemo.Server.Application.Dto;

public class UpdateDeclarationDto
{
    public string Description { get; set; } = null!;
    public string Jurisdiction { get; set; } = null!;
    public decimal NetMass { get; set; }
}