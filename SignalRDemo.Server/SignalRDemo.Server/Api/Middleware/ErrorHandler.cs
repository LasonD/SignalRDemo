using FluentValidation;
using SignalRDemo.Server.Application.Exceptions;
using System.Net;
using SignalRDemo.Server.Application.Dto;

namespace SignalRDemo.Server.Api.Middleware;

internal class ErrorHandler : IMiddleware
{
    private const string DefaultFallbackErrorMessage = "Something went wrong.";

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        if (exception is ValidationException validationException)
        {
            await HandleValidationExceptionAsync(context, validationException);
        }

        if (exception is AuthException authException)
        {
            await WriteErrorResponse(context, HttpStatusCode.Unauthorized, new List<string> { authException.Message });
        }

        if (exception is BusinessException businessException)
        {
            await WriteErrorResponse(context, HttpStatusCode.BadRequest, new List<string> { businessException.Message });
        }
    }

    private static async Task HandleValidationExceptionAsync(HttpContext context, ValidationException validationException)
    {
        var errors = validationException.Errors.ToList();

        var statusCode = HttpStatusCode.BadRequest;

        if (errors.Any(e => e.ErrorCode == Constants.UnauthorizedErrorCode))
        {
            statusCode = HttpStatusCode.Unauthorized;
        }

        var errorMessages = errors
            .Select(e => e.ErrorMessage)
            .Where(e => !string.IsNullOrWhiteSpace(e))
            .ToList();

        await WriteErrorResponse(context, statusCode, errorMessages);
    }

    private static Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, ICollection<string> errors)
    {
        context.Response.StatusCode = (int)statusCode;

        if (errors.Count == 0)
        {
            errors.Add(DefaultFallbackErrorMessage);
        }

        return context.Response.WriteAsJsonAsync(new ErrorDetails
        {
            StatusCode = statusCode,
            Errors = errors?.ToList()
        });
    }
}