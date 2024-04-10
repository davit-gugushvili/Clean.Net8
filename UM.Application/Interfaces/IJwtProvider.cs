namespace UM.Application.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateAccessToken(int userId, string role);
        string GenerateRefreshToken();
    }
}
