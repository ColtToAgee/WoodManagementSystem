﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WoodManagementSystem.Application.Features.Auth.Rules;
using WoodManagementSystem.Application.Features.Users.Rules;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;
        private readonly UserRules userRules;
        private readonly AuthRules authRules;

        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,UserRules userRules,AuthRules authRules)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.userRules = userRules;
            this.authRules = authRules;
        }
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserCommandResponse();
            var authorizedUser = httpContextAccessor.HttpContext.User;
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            await userRules.YouCannotChangeAnotherUserInformation(Convert.ToInt32(authorizedUser.FindFirst(ClaimTypes.NameIdentifier).Value), request.Id);

            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            var map = mapper.Map<User, UpdateUserCommandRequest>(request);


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
