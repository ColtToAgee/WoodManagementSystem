using MediatR;
using WoodManagementSystem.Application.Features.Users.Rules;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserRules userRules;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,UserRules userRules)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userRules = userRules;
        }
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserCommandResponse();
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            await userRules.UserIsNotFound(user);

            var map = mapper.Map<User,UpdateUserCommandRequest>(request);

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
