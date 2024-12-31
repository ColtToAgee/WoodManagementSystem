using MediatR;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Orders.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateOrderCommandResponse();
            Order newOrder = new Order(request.PatternId, request.CreatedUserId);

            await unitOfWork.GetWriteRepository<Order>().AddAsync(newOrder);
            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var orderDetail in request.OrderDetails)
                {
                    orderDetail.OrderId = newOrder.Id;
                    await unitOfWork.GetWriteRepository<OrderDetails>().AddAsync(orderDetail);
                }
                await unitOfWork.SaveAsync();
                response.IsSuccess = true;
                response.Message = "Sipariş Oluşturuldu";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Sipariş Oluşturulamadı";
            }
            return response;
        }
    }
}
