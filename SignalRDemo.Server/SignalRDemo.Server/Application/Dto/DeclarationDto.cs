namespace SignalRDemo.Server.Application.Dto;

public class DeclarationDto
{
    public string Id { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Jurisdiction { get; set; } = null!;
    public string DisplayColor { get; set; } = null!;
    public decimal NetMass { get; set; }
    public string DeclarantEmail { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public DateTime? LastUpdatedDate { get; set; }
    public string DeclarantId { get; set; } = null!;
    public bool IsLocked { get; set; }
}