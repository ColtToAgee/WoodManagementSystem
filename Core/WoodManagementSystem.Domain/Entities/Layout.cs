namespace WoodManagementSystem.Domain.Entities
{
    public class Layout
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public List<CustomerCartItem> Rects { get; set; }
    }
}
