using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace SignalRDemo.Server.Infrastructure.Validation;

public sealed class ValidationBehavior<TResponse> : IPipelineBehavior<IRequest<TResponse>, TResponse>
{
    private readonly IEnumerable<IValidator<IRequest<TResponse>>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<IRequest<TResponse>>> validators) => _validators = validators;

    public async Task<TResponse> Handle(IRequest<TResponse> request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<IRequest<TResponse>>(request);

        var errors = new List<ValidationFailure>();

        foreach (var validator in _validators)
        {
            var validationResult = await validator.ValidateAsync(context, cancellationToken);

            if (!validationResult.IsValid)
            {
                errors.AddRange(errors);
            }
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return await next();
    }
}