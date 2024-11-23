using WoodManagementSystem.Domain.Common;

namespace WoodManagementSystem.Domain.Entities
{
    public class Order : EntityBase, IEntityBase
    {
        public int PatternId { get; set; }
        public Pattern Pattern { get; set; }
        public bool IsPaid { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime PaidDate { get; set; }
        ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
