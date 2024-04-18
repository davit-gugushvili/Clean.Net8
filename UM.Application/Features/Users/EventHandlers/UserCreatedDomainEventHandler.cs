namespace UM.Application.Features.Users.EventHandlers
{
    internal sealed class UserCreatedDomainEventHandler(IEmailService emailService)
        : INotificationHandler<UserCreatedDomainEvent>
    {
        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await emailService.SendEmailAsync(
                notification.User.Email, "Account Creation", "Your account has been successfully created!", cancellationToken);
        }
    }
}
