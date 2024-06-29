using Online_sms.Models;

namespace Online_sms.Services
{
    public interface IMailService
    {
        public Task SendMailAsync(MailRequest mailRequest);
    }
}
