using System.Net.Mail;
using System.Text.Encodings.Web;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Persistence.IRepository;

namespace Services
{
    public class CustomEmailSender : ICustomEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25,
            });

            Email.DefaultSender = sender;

            var sendingMail = await Email.From("EMAIL_FROM").To(email).Subject(subject).Body(htmlMessage).SendAsync();
        }

        public async Task SendResetPasswordTokenAsync(string email, string callbackUrl)
        {
            string subject = "Sotex Staff hub - Your account is created";
            string message = $"Please set your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";

            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25,
            });
            
            Email.DefaultSender = sender;

            var sendingMail = await Email
                .From("EMAIL_FROM")
                .To(email)
                .Subject(subject)
                .Body(message)
                .SendAsync();
            
        }
    }
}
