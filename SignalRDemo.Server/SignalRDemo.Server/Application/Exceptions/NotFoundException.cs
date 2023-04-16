namespace SignalRDemo.Server.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {

    }

    public NotFoundException(string id, string resourceName) : base($"{resourceName} not found with id {id}")
    {
        Id = id;
        ResourceName = resourceName;
    }

    public string? Id { get; }

    public string? ResourceName { get; }
}