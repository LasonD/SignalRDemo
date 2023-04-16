namespace SignalRDemo.Server.Application.Models;

public class Jurisdiction
{
    public Jurisdiction(string code, string name, string displayColor) : this(code)
    {
        Name = name;
        DisplayColor = displayColor;
    }

    public Jurisdiction(string code)
    {
        Code = code;
    }

    public string Name { get; init; } = null!;
    public string Code { get; init; }

    public string DisplayColor { get; set; } = null!;
}