using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using WoodManagementSystem.Application.Features.Auth.Rules;
using WoodManagementSystem.Application.Interfaces.Mails;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Auth.Command.GenerateRefreshPasswordCode
{
    public class RefreshPasswordCodeCommandHandler : IRequestHandler<RefreshPasswordCodeCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;
        private readonly IMailService mailService;

        public RefreshPasswordCodeCommandHandler(UserManager<User> userManager, AuthRules authRules,IMailService mailService)
        {
            this.userManager = userManager;
            this.authRules = authRules;
            this.mailService = mailService;
        }
        public async Task<Unit> Handle(RefreshPasswordCodeCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            await authRules.UserShouldNotBeExist(user);
            var code = await userManager.GeneratePasswordResetTokenAsync(user);
            if (code is not null)
            {
                user.RefreshPasswordCode = code;
                user.RefreshPasswordCodeExpiryTime = DateTime.UtcNow.AddMinutes(3);
                await userManager.UpdateAsync(user);
                var newMessage = new MailMessage(from:"",to: user.Email, subject: "Şifre Sıfırlama Maili", body: $"Şifre sıfırlama kodunuz: {code}");
                await mailService.SendMail(newMessage);
            }
            return Unit.Value;
        }
    }
}
