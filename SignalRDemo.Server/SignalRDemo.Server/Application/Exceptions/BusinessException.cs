namespace SignalRDemo.Server.Application.Exceptions;

public class BusinessException : Exception
{
    public BusinessException(string error) : base(error)
    {
        
    }
}