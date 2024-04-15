namespace UM.Application.Features.Auth.Login
{
    public sealed record LogInCommandDto(
        string Name, 
        string Email, 
        string Role, 
        string AccessToken, 
        string RefreshToken);
}
