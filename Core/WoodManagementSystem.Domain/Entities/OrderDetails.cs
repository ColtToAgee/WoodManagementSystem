using WoodManagementSystem.Domain.Common;

namespace WoodManagementSystem.Domain.Entities
{
    public class OrderDetails : EntityBase, IEntityBase
    {
        public double DimensionWidth { get; set; }
        public double DimensionLength { get; set; }
        public double DimensionX { get; set; }
        public double DimensionY { get; set; }
        public string EdgeBand { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
