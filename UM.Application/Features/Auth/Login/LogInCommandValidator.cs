namespace UM.Application.Features.Auth.Login
{
    public sealed class LogInCommandValidator : AbstractValidator<LogInCommand>
    {
        public LogInCommandValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Password();
        }
    }
}
