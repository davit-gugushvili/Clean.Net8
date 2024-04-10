using UM.Application.Features.Users.Commands.DeleteUser;

namespace UM.API.Endpoints.Users
{
    public sealed class DeleteUserEndpoint(IMediator mediator) 
        : Endpoint<DeleteUserCommand, Result>
    {
        public override void Configure()
        {
            Delete("users/{id}");

            Policies("AdminsOnly");
        }

        public override async Task HandleAsync(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            await SendResultAsync(result.ToMinimalApiResult());
        }
    }
}
