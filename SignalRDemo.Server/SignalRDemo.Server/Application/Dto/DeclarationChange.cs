namespace SignalRDemo.Server.Application.Dto;

public class DeclarationChange
{
    public string Id { get; set; } = null!;

    public object Changes { get; set; } = null!;
}