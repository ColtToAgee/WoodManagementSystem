using MediatR;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Carts.Command.AddCartItem
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommandRequest, AddCartItemCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddCartItemCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<AddCartItemCommandResponse> Handle(AddCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new AddCartItemCommandResponse();
            var newCustomerCartItemList = new List<CustomerCartItem>();
            foreach(var customerCartItem in request.CustomerCartItems)
            {
                CustomerCartItem newCustomerCartItem = new CustomerCartItem(customerCartItem.CustomerCartId, customerCartItem.PatternId, customerCartItem.DimensionWidth, customerCartItem.DimensionLength, customerCartItem.EdgeBand);
                newCustomerCartItemList.Add(newCustomerCartItem);
            }

            await unitOfWork.GetWriteRepository<CustomerCartItem>().AddRangeAsync(newCustomerCartItemList);

            if (await unitOfWork.SaveAsync() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Sepete Eklendi";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Sepete Eklenemedi";
            }
            return response;
        }
    }
}
