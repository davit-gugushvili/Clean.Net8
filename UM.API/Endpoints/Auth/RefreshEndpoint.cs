using UM.Application.Features.Auth.Login;

namespace UM.API.Endpoints.Auth
{
    public sealed class RefreshEndpoint(IMediator mediator)
        : Endpoint<RefreshQuery, Result<string>>
    {
        public override void Configure()
        {
            Post("auth/refresh");
        }

        public override async Task HandleAsync(RefreshQuery request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            await SendResultAsync(result.ToMinimalApiResult());
        }
    }
}
