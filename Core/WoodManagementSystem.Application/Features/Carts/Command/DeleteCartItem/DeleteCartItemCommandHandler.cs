using MediatR;
using WoodManagementSystem.Application.Features.Carts.Rules;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Carts.Command.DeleteCartItem
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommandRequest, DeleteCartItemCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CartItemRules cartItemRules;

        public DeleteCartItemCommandHandler(IUnitOfWork unitOfWork, CartItemRules cartItemRules)
        {
            this.unitOfWork = unitOfWork;
            this.cartItemRules = cartItemRules;
        }
        public async Task<DeleteCartItemCommandResponse> Handle(DeleteCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCartItemCommandResponse();
            var cartItem = await unitOfWork.GetReadRepository<CustomerCartItem>().GetAsync(x => x.Id == request.Id);
            await cartItemRules.CartItemIsNotFound(cartItem);

            await unitOfWork.GetWriteRepository<CustomerCartItem>().HardDeleteAsync(cartItem);

            if (await unitOfWork.SaveAsync() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Sepetteki Ürün Silindi";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Sepeteki Ürün Silinemedi";
            }
            return response;
        }
    }
}
