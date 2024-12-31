using MediatR;
using WoodManagementSystem.Application.Features.Orders.Rules;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Orders.Command.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly OrderRules orderRules;

        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, OrderRules orderRules)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.orderRules = orderRules;
        }
        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteOrderCommandResponse();
            var order = await unitOfWork.GetReadRepository<Order>().GetAsync(x => x.Id == request.Id);

            await orderRules.OrderIsNotFound(order);

            order.IsCancelled = true;

            await unitOfWork.GetWriteRepository<Order>().UpdateAsync(order);
            if (await unitOfWork.SaveAsync() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Sipariş İptal Edildi";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Sipariş İptal Edilemedi";
            }
            return response;

        }
    }
}
