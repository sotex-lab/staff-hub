using System.Net;
using System.Net.Mail;
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

            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("nikola.j00@gmail.com", "GMAIL_PASS"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("nikola.j00@gmail.com"),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }


            return Task.CompletedTask;
        }

    }
}
