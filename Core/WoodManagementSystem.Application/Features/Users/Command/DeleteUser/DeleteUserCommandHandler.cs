using MediatR;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Application.Features.Users.Rules;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserRules userRules;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork,UserRules userRules)
        {
            this.unitOfWork = unitOfWork;
            this.userRules = userRules;
        }
        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteUserCommandResponse();
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            await userRules.UserIsNotFound(user);   

            await unitOfWork.GetWriteRepository<User>().HardDeleteAsync(user);
            if (await unitOfWork.SaveAsync() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Kullanıcı Başarıyla Silindi";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Kullanıcı Silinemedi";
            }
            return response;
        }
    }
}
