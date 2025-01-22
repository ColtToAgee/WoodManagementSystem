using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Net.Mail;
using WoodManagementSystem.Application.Interfaces.Mails;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Infrastructure.Mails
{
    public class MailService : IMailService
    {
        private readonly MailSettings mailSettings;
        private readonly IUnitOfWork unitOfWork;
        static string status = "";

        public MailService(IOptions<MailSettings> mailSettings,IUnitOfWork unitOfWork)
        {
            this.mailSettings = mailSettings.Value;
            this.unitOfWork = unitOfWork;
        }
        public async Task SendMail(MailMessage message)
        {
            SmtpClient client = new SmtpClient();
            MailAddress fromTo = new MailAddress(mailSettings.FromTo);
            message.From = fromTo;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userState = "test";
            client.SendAsync(message, userState);
            message.Dispose();


            //Gönderilen maillerin logunu tutma işlemi
            var mailLog = new MailLog()
            {
                FromTo = mailSettings.FromTo,
                SendTo = message.To.ToString(),
                Subject = message.Subject,
                Body = message.Body,
                SendDate = DateTime.Now,
                Status = status
            };
            await unitOfWork.GetWriteRepository<MailLog>().AddAsync(mailLog);
        }
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                status = "Mail gönderilirken bir hata ile karşılaşıldı";
            }
            else
            {
                status = "Mail gönderildi.";
            }
        }
    }
}
