namespace UM.SharedKernel.PipelineBehaviors
{
    public sealed class ValidationBehavior<TRequest, _>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, Result> where TRequest : IRequest<Result>
    {
        public async Task<Result> Handle(TRequest request, RequestHandlerDelegate<Result> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(validators.Select(validator => validator.ValidateAsync(context)));

            if (validationFailures.Any(x => !x.IsValid))
            {
                var validationErrors = validationFailures.Where(x => !x.IsValid).SelectMany(x => x.GetValidationErrors()).ToList();

                return Result.Failure(validationErrors);
            }

            return await next();
        }
    }

    public sealed class ValidationBehaviorGeneric<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, Result<TResponse>> where TRequest : IRequest<Result<TResponse>>
    {
        public async Task<Result<TResponse>> Handle(TRequest request, RequestHandlerDelegate<Result<TResponse>> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(validators.Select(validator => validator.ValidateAsync(context)));

            if (validationFailures.Any(x => !x.IsValid))
            {
                var validationErrors = validationFailures.Where(x => !x.IsValid).SelectMany(x => x.GetValidationErrors()).ToList();

                return Result.Failure(validationErrors);
            }

            return await next();
        }
    }
}
