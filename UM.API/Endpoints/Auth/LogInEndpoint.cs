using UM.Application.Features.Auth.Login;

namespace UM.API.Endpoints.Auth
{
    public sealed class LogInEndpoint(IMediator mediator)
        : Endpoint<LogInCommand, Result<LogInCommandDto>>
    {
        public override void Configure()
        {
            Post("auth/login");

            AllowAnonymous();
        }

        public override async Task HandleAsync(LogInCommand request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            await SendResultAsync(result.ToMinimalApiResult());
        }
    }
}
