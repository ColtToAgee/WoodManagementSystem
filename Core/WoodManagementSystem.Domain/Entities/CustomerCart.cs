using WoodManagementSystem.Domain.Common;

namespace WoodManagementSystem.Domain.Entities
{
    public class CustomerCart : EntityBase, IEntityBase
    {
        public CustomerCart()
        {

        }
        public CustomerCart(int customerId)
        {
            this.CustomerUserId = customerId;
        }
        public double TotalCost { get; set; }
        public bool IsOrdered { get; set; }
        public int CustomerUserId { get; set; }
        public ICollection<CustomerCartItem> CustomerCartItems { get; set; }

    }
}
