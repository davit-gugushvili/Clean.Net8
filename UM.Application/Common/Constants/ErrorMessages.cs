namespace UM.Application.Common.Constants
{
    internal static class ErrorMessages
    {
        public static readonly Error InvalidCredentials = new Error(nameof(InvalidCredentials), "Invalid Credentials");
        public static readonly Error EmailAlreadyExists = new Error(nameof(EmailAlreadyExists), "Email Already Exists");
        public static readonly Error UserNotFound = new Error(nameof(UserNotFound), "User Not Found");
        public static readonly Error RefreshTokenNotFound = new Error(nameof(RefreshTokenNotFound), "Refresh Token Not Found");
    }
}