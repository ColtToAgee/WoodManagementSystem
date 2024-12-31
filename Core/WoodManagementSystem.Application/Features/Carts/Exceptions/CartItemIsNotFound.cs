using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Carts.Exceptions
{
    public class CartItemIsNotFound : BaseException
    {
        public CartItemIsNotFound() : base("Sepetteki Ürün Bulunamadı")
        {

        }
    }
}
