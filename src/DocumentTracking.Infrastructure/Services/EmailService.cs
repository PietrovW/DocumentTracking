using DocumentTracking.Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailOptions> emailOptions;
        public EmailService(IOptions<EmailOptions> emailOptions)
        {
            this.emailOptions = emailOptions;
        }

        public async Task SendAsync(MailMessage message)
        {
            using (SmtpClient SmtpServer = new SmtpClient(emailOptions.Value.Smtp))
            {
                SmtpServer.Port = emailOptions.Value.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emailOptions.Value.Username, emailOptions.Value.Password);
                SmtpServer.EnableSsl = true;
               await SmtpServer.SendMailAsync(message);
            }
        }
    }
}
