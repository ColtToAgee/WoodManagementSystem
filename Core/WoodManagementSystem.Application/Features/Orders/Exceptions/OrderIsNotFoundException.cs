using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Orders.Exceptions
{
    public class OrderIsNotFoundException : BaseException
    {
        public OrderIsNotFoundException() : base("Sipariş Bulunamadı")
        {

        }
    }
}
