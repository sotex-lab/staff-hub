namespace Persistence.IRepository
{
    public interface ICustomEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
        Task SendResetPasswordTokenAsync(string email, string callbackUrl);
    }
}
