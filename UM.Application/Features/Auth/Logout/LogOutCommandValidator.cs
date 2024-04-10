namespace UM.Application.Features.Auth.Login
{
    public sealed class LogOutCommandValidator : AbstractValidator<LogOutCommand>
    {
        public LogOutCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
