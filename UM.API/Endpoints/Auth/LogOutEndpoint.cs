using UM.Application.Features.Auth.Login;

namespace UM.API.Endpoints.Auth
{
    public sealed class LogoutEndpoint(IMediator mediator)
        : Endpoint<LogOutCommand, Result>
    {
        public override void Configure()
        {
            Post("auth/logout");
        }

        public override async Task HandleAsync(LogOutCommand request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            await SendResultAsync(result.ToMinimalApiResult());
        }
    }
}
