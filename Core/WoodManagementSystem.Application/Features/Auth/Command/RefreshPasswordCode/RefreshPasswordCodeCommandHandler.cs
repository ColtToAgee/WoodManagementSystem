using MediatR;
using Microsoft.AspNetCore.Identity;
using WoodManagementSystem.Application.Features.Auth.Rules;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Auth.Command.GenerateRefreshPasswordCode
{
    public class RefreshPasswordCodeCommandHandler : IRequestHandler<RefreshPasswordCodeCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;

        public RefreshPasswordCodeCommandHandler(UserManager<User> userManager, AuthRules authRules)
        {
            this.userManager = userManager;
            this.authRules = authRules;
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
            }
            return Unit.Value;
        }
    }
}
