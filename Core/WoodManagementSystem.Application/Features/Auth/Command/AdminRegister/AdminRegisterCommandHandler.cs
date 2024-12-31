using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WoodManagementSystem.Application.Bases;
using WoodManagementSystem.Application.Features.Auth.Rules;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Auth.Command.AdminRegister
{
    public class AdminRegisterCommandHandler : BaseHandler, IRequestHandler<AdminRegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        public AdminRegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(AdminRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User, AdminRegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp=Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user,request.Password);
            if (result.Succeeded)
            {
                if(!await roleManager.RoleExistsAsync("admin"))
                {
                    await roleManager.CreateAsync(new Role
                    {
                        Name = "admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
                }
                await userManager.AddToRoleAsync(user, "admin");
            }

            return Unit.Value;
        }
    }
}
