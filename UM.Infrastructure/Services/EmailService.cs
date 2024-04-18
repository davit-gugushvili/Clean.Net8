namespace UM.Infrastructure.Services
{
    public sealed class EmailService : IEmailService
    {
        public Task SendEmailAsync(string emailTo, string subject, string body, CancellationToken cancellationToken = default) 
        {
            return Task.CompletedTask;
        }
    }
}
