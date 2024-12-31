using FluentValidation;

namespace WoodManagementSystem.Application.Features.Orders.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersValidator : AbstractValidator<GetCustomerOrdersQueryRequest>
    {
        public GetCustomerOrdersValidator()
        {
            RuleFor(x => x.CustomerUserId).NotEmpty();
        }
    }
}
