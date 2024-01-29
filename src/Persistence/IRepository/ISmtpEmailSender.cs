namespace Persistence.IRepository
{
    public interface ISmtpEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
        Task SendResetPasswordTokenAsync(string email, string callbackUrl);
    }
}
