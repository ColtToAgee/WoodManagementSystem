namespace WoodManagementSystem.Application.DTOs
{
    public class CustomerCartItemDto
    {
        public int? PatternId { get; set; }
        public double? DimensionWidth { get; set; }
        public double? DimensionLength { get; set; }
        public double? DimensionX { get; set; }
        public double? DimensionY { get; set; }
        public string? EdgeBand { get; set; }
    }
}
