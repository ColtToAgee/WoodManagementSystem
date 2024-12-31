using WoodManagementSystem.Domain.Common;

namespace WoodManagementSystem.Domain.Entities
{
    public class CustomerCartItem : EntityBase, IEntityBase
    {
        public CustomerCartItem()
        {
            
        }
        public CustomerCartItem(int cartId,int patternId,double dimensionWidth,double dimensionLength,string edgeBand)
        {
            this.CustomerCartId = cartId;
            this.PatternId = patternId;
            this.DimensionWidth = dimensionWidth;
            this.DimensionLength = dimensionLength;
            this.EdgeBand = edgeBand;
        }
        public int CustomerCartId { get; set; }
        public int PatternId { get; set; }
        public double DimensionWidth { get; set; }
        public double DimensionLength { get; set; }
        public double DimensionX { get; set; }
        public double DimensionY { get; set; }
        public string EdgeBand { get; set; } //1.5 cm tıraşlama payı,4 mm kesim payı
        public CustomerCart CustomerCart { get; set; }
        public Pattern Pattern { get; set; }
    }
}
