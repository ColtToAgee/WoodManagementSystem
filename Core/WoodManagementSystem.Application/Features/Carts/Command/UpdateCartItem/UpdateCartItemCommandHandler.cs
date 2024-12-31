using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Application.Features.Carts.Rules;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Carts.Command.UpdateCartItem
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommandRequest, UpdateCartItemCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly CartItemRules cartItemRules;

        public UpdateCartItemCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,CartItemRules cartItemRules)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.cartItemRules = cartItemRules;
        }
        public async Task<UpdateCartItemCommandResponse> Handle(UpdateCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCartItemCommandResponse();
            var customerCartItem = await unitOfWork.GetReadRepository<CustomerCartItem>().GetAsync(x => x.Id == request.Id && !x.IsDeleted && !x.CustomerCart.IsOrdered);
            await cartItemRules.CartItemIsNotFound(customerCartItem);

            var map = mapper.Map<CustomerCartItem, UpdateCartItemCommandRequest>(request);

            await unitOfWork.GetWriteRepository<CustomerCartItem>().UpdateAsync(map);
            if (await unitOfWork.SaveAsync() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Sepetteki Ürün Başarıyla Güncellendi";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Sepetteki Ürün Güncellenemedi";
            }
            return response;
        }
    }
}
