using System.Net.Mail;

namespace WoodManagementSystem.Application.Interfaces.Mails
{
    public interface IMailService
    {
        Task SendMail(MailMessage message);
    }
}
