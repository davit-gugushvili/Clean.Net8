using UM.Application.Features.Users.Commands.CreateUser;

namespace UM.API.Endpoints.Users
{
    public sealed class CreateUserEndpoint(IMediator mediator) 
        : Endpoint<CreateUserCommand, Result<int>>
    {
        public override void Configure()
        {
            Post("users");

            Policies("AdminsOnly");

            Version(1, deprecateAt: 2);
        }

        public override async Task HandleAsync(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            await SendResultAsync(result.ToMinimalApiResult());
        }
    }

    public sealed class CreateUserEndpoint_V2(IMediator mediator)
        : Endpoint<CreateUserCommand, Result<int>>
    {
        public override void Configure()
        {
            Post("users");

            Policies("AdminsOnly");

            Version(2);
        }

        public override async Task HandleAsync(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            await SendResultAsync(result.ToMinimalApiResult());
        }
    }
}
