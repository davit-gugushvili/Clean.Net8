namespace UM.Application.Features.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
