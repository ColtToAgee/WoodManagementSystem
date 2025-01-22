using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WoodManagementSystem.Application.Features.Auth.Rules;
using WoodManagementSystem.Application.Features.Users.Rules;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Users.Command.UpdateUser
{
    public class AdminUpdateUserCommandHandler : IRequestHandler<AdminUpdateUserCommandRequest, AdminUpdateUserCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly UserRules userRules;
        private readonly AuthRules authRules;

        public AdminUpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,UserManager<User> userManager, UserRules userRules,AuthRules authRules)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.userRules = userRules;
            this.authRules = authRules;
        }
        public async Task<AdminUpdateUserCommandResponse> Handle(AdminUpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new AdminUpdateUserCommandResponse();
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            await userRules.UserIsNotFound(user);
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));
            var map = mapper.Map<User,AdminUpdateUserCommandRequest>(request);

            await unitOfWork.GetWriteRepository<User>().UpdateAsync(map);
            if (await unitOfWork.SaveAsync() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Kullanıcı Başarıyla Güncellendi";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Kullanıcı Güncellenemedi";
            }
            return response;
        }
    }
}
