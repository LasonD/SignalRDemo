namespace SignalRDemo.Server.Models;

public class Jurisdiction
{
    public Jurisdiction(string code, string name) : this(code)
    {
        Name = name;
    }

    public Jurisdiction(string code)
    {
        Code = code;
    }

    public string Name { get; init; } = null!;
    public string Code { get; init; }
}