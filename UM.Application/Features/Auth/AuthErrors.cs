namespace UM.Application.Features.Auth
{
    internal class AuthErrors
    {
        public static readonly Error InvalidCredentials = new Error(nameof(InvalidCredentials), "Invalid Credentials");
        public static readonly Error RefreshTokenNotFound = new Error(nameof(RefreshTokenNotFound), "Refresh Token Not Found");
        public static readonly Error RefreshTokenExpired = new Error(nameof(RefreshTokenExpired), "Refresh Token Expired");
    }
}
