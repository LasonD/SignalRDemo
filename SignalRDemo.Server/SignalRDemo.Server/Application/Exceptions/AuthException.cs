namespace SignalRDemo.Server.Application.Exceptions;

public class AuthException : Exception
{
    public AuthException(string error)
    {
        Errors = new List<string>() { error };
    }

    public AuthException(List<string> errors)
    {
        Errors = errors;
    }

    public List<string> Errors { get; set; }
}