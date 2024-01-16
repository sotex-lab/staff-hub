using System.Text.Encodings.Web;
using Persistence.IRepository;

namespace Services
{
    public class CustomEmailSender : ICustomEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }

        public Task SendResetPasswordTokenAsync(string email, string callbackUrl)
        {
            string subject = "Sotex Staff hub - Your account is created";
            string message = $"Please set your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";

            //here will be SendGrid logic

            return Task.CompletedTask;
        }

    }
}
