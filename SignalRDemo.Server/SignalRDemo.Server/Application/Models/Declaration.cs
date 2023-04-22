namespace SignalRDemo.Server.Application.Models;

public class Declaration
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public decimal NetMass { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    public string JurisdictionCode { get; set; } = null!;
    public Jurisdiction Jurisdiction { get; set; } = null!;

    public string DeclarantId { get; set; } = null!;
    public User Declarant { get; set; } = null!;
}