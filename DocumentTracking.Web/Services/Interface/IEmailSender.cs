using System.Net.Mail;
using System.Threading.Tasks;

namespace DocumentTracking.Services
{
    public interface IEmailService
    {
        Task SendAsync(MailMessage message);
    }
}
