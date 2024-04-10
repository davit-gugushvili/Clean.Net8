namespace UM.Application.Features.Auth.Login
{
    public sealed record RefreshQuery : IRequest<Result<string>>
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}
