namespace WoodManagementSystem.Domain.Entities
{
    public class Bound
    {
        public Bound(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
