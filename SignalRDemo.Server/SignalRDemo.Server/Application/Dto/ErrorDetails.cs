using System.Net;

namespace SignalRDemo.Server.Application.Dto;

public class ErrorDetails
{
    public HttpStatusCode StatusCode { get; set; }

    public IEnumerable<string>? Errors { get; set; }
}