namespace SignalRDemo.Server.Dto;

public record Error(string Message, bool IsClientFacing = true)
{
    public static implicit operator string?(Error? error)
    {
        if (error is null)
        {
            return null;
        }

        return error.IsClientFacing ? error.Message : "Something went wrong...";
    }
}