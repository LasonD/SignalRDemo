namespace SignalRDemo.Server.Application.Models;

public class Declaration
{
    public string Id { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal NetMass { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    public DateTime? LastUpdatedDate{ get; set; }

    public string JurisdictionCode { get; set; } = null!;
    public Jurisdiction Jurisdiction { get; set; } = null!;

    public string DeclarantId { get; set; } = null!;
    public User Declarant { get; set; } = null!;
}