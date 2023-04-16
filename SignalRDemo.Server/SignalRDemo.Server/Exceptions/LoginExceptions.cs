namespace SignalRDemo.Server.Exceptions;

public class LoginException : AuthException
{
    public LoginException(List<string> errors) : base(errors)
    {
    }
}