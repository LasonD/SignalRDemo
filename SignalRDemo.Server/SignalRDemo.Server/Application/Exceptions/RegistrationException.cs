namespace SignalRDemo.Server.Application.Exceptions;

public class RegistrationException : AuthException
{
    public RegistrationException(List<string> errors) : base(errors)
    {
    }
}