using UM.Application.Features.Users.Queries;
using UM.Application.Features.Users.Queries.GetUsers;

namespace UM.API.Endpoints.Users
{
    public sealed class GetUsersEndpoint(IMediator mediator) 
        : Endpoint<GetUsersQuery, Result<PaginatedList<UserDto>>>
    {
        public override void Configure()
        {
            Get("users");
        }

        public override async Task HandleAsync(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            await SendResultAsync(result.ToMinimalApiResult());
        }
    }
}
