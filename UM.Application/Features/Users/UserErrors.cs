namespace UM.Application.Features.Users
{
    internal class UserErrors
    {
        public static readonly Error EmailAlreadyExists = new Error(nameof(EmailAlreadyExists), "Email Already Exists");
    }
}
