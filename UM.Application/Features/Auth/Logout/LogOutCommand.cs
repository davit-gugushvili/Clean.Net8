namespace UM.Application.Features.Auth.Login
{
    public sealed record LogOutCommand : IRequest<Result>
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}
