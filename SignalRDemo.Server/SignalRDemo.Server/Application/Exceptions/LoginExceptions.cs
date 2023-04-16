namespace SignalRDemo.Server.Application.Exceptions;

public class LoginException : AuthException
{
    public LoginException(List<string> errors) : base(errors)
    {
    }
}