using UM.Application.Features.Users.Commands.UpdateUser;

namespace UM.API.Endpoints.Users
{
    public sealed class UpdateUserEndpoint(IMediator mediator) 
        : Endpoint<UpdateUserCommand, Result>
    {
        public override void Configure()
        {
            Put("users/{id}");

            Policies("AdminsOnly");
        }

        public override async Task HandleAsync(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            await SendResultAsync(result.ToMinimalApiResult());
        }
    }
}
