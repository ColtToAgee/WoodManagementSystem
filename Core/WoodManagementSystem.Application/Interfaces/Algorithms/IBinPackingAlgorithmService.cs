using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Interfaces.Algorithms
{
    public interface IBinPackingAlgorithmService
    {
        bool Intersects(CustomerCartItem a, CustomerCartItem b);
        bool Validate(List<CustomerCartItem> rects, CustomerCartItem rect);
        double WhiteSpace(Layout layout);
        double Rate(Layout layout);
        Bound FindBounds(List<CustomerCartItem> CustomerCartItem);
        List<Position> FindPositions(List<CustomerCartItem> CustomerCartItem);
        CustomerCartItem FindBestRect(Layout layout, CustomerCartItem size);
        List<int> PreOrder(List<CustomerCartItem> sizes);
        Layout ReOrder(Layout layout, List<int> order);
        public List<Layout> Pack(List<CustomerCartItem> sizes, Pattern pattern, List<Layout> layoutList);
    }
}
