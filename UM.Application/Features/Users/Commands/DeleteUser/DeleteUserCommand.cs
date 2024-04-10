namespace UM.Application.Features.Users.Commands.DeleteUser
{
    public sealed record DeleteUserCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
