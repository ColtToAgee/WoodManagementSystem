using WoodManagementSystem.Domain.Common;

namespace WoodManagementSystem.Domain.Entities
{
    public class Order : EntityBase, IEntityBase
    {
        public Order()
        {
            
        }
        public Order(int patternId,int createdUserId)
        {
            this.PatternId = patternId;
            this.CreatedUserId = createdUserId;
        }
        public int PatternId { get; set; }
        public Pattern Pattern { get; set; }
        public int CreatedUserId { get; set; }
        public bool IsCancelled { get; set; } = false;
        ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
