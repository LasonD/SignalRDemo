namespace SignalRDemo.Server.Application.Models;

public class Jurisdiction
{
    public Jurisdiction(string code, string displayColor) : this(code)
    {
        DisplayColor = displayColor;
    }

    public Jurisdiction(string code)
    {
        Code = code;
    }

    public string Code { get; init; }

    public string DisplayColor { get; set; } = null!;
}