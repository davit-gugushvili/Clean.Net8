using UM.Application.Features.Users.Queries;
using UM.Application.Features.Users.Queries.GetUserById;

namespace UM.API.Endpoints.Users
{
    public sealed class GetUserByIdEndpoint(IMediator mediator) 
        : Endpoint<GetUserByIdQuery, Result<UserDto>>
    {
        public override void Configure()
        {
            Get("users/{id}");
        }

        public override async Task HandleAsync(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            await SendResultAsync(result.ToMinimalApiResult());
        }
    }
}
