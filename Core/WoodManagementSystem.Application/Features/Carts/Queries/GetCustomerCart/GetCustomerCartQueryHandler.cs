using MediatR;
using WoodManagementSystem.Application.DTOs;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Carts.Queries.GetCustomerCart
{
    public class GetCustomerCartQueryHandler : IRequestHandler<GetCustomerCartQueryRequest, GetCustomerCartQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerCartQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<GetCustomerCartQueryResponse> Handle(GetCustomerCartQueryRequest request, CancellationToken cancellationToken)
        {
            var customerCart = await unitOfWork.GetReadRepository<CustomerCart>().GetAsync(x => x.CustomerUserId == request.CustomerUserId);
            var customerCartItems = mapper.Map<CustomerCartItemDto, CustomerCartItem>(new CustomerCartItem());

            var map = mapper.Map<GetCustomerCartQueryResponse, CustomerCart>(customerCart);

            return map;
        }
    }
}
