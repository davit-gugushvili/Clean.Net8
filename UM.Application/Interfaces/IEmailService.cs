namespace UM.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailTo, string subject, string body, CancellationToken cancellationToken);
    }
}
