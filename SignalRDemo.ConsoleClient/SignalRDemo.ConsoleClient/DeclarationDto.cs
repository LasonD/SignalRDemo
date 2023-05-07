namespace SignalRDemo.ConsoleClient;

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

    public override string ToString()
    {
        var separator = new string('-', 80);
        var header = $"{"ID",-20} {"Description",-20} {"Jurisdiction",-20} " +
                     $"{"Display Color",-20} {"Net Mass",-20} {"Declarant Email",-20} " +
                     $"{"Creation Date",-20} {"Last Updated Date",-20} {"Declarant ID",-20} " +
                     $"{"Is Locked",-20}";
        var data = $"{Id,-20} {Description,-20} {Jurisdiction,-20} " +
                   $"{DisplayColor,-20} {NetMass,-20} {DeclarantEmail,-20} " +
                   $"{CreationDate,-20} {LastUpdatedDate,-20} {DeclarantId,-20} " +
                   $"{IsLocked,-20}";

        return $"{separator}\n{header}\n{separator}\n{data}\n{separator}";
    }
}