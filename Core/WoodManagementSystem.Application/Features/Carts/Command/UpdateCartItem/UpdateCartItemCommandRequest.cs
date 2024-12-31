using MediatR;

namespace WoodManagementSystem.Application.Features.Carts.Command.UpdateCartItem
{
    public class UpdateCartItemCommandRequest : IRequest<UpdateCartItemCommandResponse>
    {
        public int Id { get; set; }
        public int CustomerCartId { get; set; }
        public int PatternId { get; set; }
        public double DimensionWidth { get; set; }
        public double DimensionLength { get; set; }
        public string EdgeBand { get; set; }
    }
}
