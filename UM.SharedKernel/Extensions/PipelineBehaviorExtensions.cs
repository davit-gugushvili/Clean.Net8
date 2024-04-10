using Microsoft.Extensions.DependencyInjection;
using UM.SharedKernel.PipelineBehaviors;

namespace UM.SharedKernel.Extensions
{
    public static class PipelineBehaviorExtensions
    {
        public static MediatRServiceConfiguration AddValidationBehavior<TRequest, TResponse>(this MediatRServiceConfiguration config)
            where TRequest : IRequest<Result<TResponse>>
        {
            return config.AddBehavior(
                typeof(IPipelineBehavior<TRequest, Result<TResponse>>),
                typeof(ValidationBehaviorGeneric<TRequest, TResponse>), ServiceLifetime.Transient);
        }
    }
}
