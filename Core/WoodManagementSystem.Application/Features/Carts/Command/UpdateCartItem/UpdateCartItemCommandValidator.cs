using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodManagementSystem.Application.Features.Carts.Command.UpdateCartItem
{
    public class UpdateCartItemCommandValidator:AbstractValidator<UpdateCartItemCommandRequest>
    {
        public UpdateCartItemCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CustomerCartId).NotEmpty();
            RuleFor(x => x.PatternId).NotEmpty();
            RuleFor(x => x.DimensionWidth).NotEmpty().WithName("Genişlik");
            RuleFor(x => x.DimensionLength).NotEmpty().WithName("Yükseklik");
        }
    }
}
