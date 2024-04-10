namespace UM.Application.Features.Auth.Login
{
    public sealed record LogInCommand : IRequest<Result<LogInCommandDto>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
