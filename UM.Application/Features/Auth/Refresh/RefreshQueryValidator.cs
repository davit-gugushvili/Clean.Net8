namespace UM.Application.Features.Auth.Login
{
    public sealed class RefreshQueryValidator : AbstractValidator<LogOutCommand>
    {
        public RefreshQueryValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
