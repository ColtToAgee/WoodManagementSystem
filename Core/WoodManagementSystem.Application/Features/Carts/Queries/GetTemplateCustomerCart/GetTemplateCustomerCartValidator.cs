using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodManagementSystem.Application.Features.Carts.Queries.GetTemplateCustomerCart
{
    public class GetTemplateCustomerCartValidator:AbstractValidator<GetTemplateCustomerCartQueryRequest>
    {
        public GetTemplateCustomerCartValidator()
        {
            RuleFor(a=>a.PatternId).NotEmpty();
            RuleFor(a => a.CustomerCartItems).NotEmpty();
        }
    }
}
