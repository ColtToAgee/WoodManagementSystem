using Newtonsoft.Json;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.CatoTest
{
    public class CatoAlgortihm
    {
        private Pattern pattern;
        public CatoAlgortihm(Pattern pattern)
        {
            this.pattern = pattern;
        }
        public List<CustomerCartItem> Order(List<CustomerCartItem> sizes)
        {
            sizes.Sort((a, b) => { return (int)(b.DimensionWidth * b.DimensionLength - a.DimensionWidth * a.DimensionLength); });
            return sizes;
        }
        public List<Position> FindAllPositions(Layout layout, Pattern pattern)
        {
            var positions = new List<Position>();
            for(int i = 0; i < pattern.Width; i++)
            {
                var avaibleX = true;
                for (int j = 0; j < pattern.Height; j++)
                {
                    var avaibleY = true;
                    if(layout.Rects is null || layout.Rects.Count() == 0)
                    {
                        positions.Add(new Position(i, j));
                    }
                    else
                    {
                        foreach (var rect in layout.Rects)
                        {
                            if (i < rect.DimensionX + rect.DimensionWidth && j < rect.DimensionY + rect.DimensionLength)
                            {
                                avaibleX = false;
                                avaibleY = false;
                            }
                            if (avaibleX && avaibleY)
                                positions.Add(new Position(i, j));
                        }
                    }
                }
            }
            return positions;
        }
        public CustomerCartItem FindBestPosition(Layout layout, CustomerCartItem size)
        {
            var bestScore = double.PositiveInfinity;
            var avaiblePositions = FindAllPositions(layout,pattern);
            foreach(var position in avaiblePositions)
            {
                var canBePlaced = avaiblePositions.Any(a => 
                (position.X + a.X) >= (size.DimensionX + size.DimensionWidth) && (position.Y + a.Y) > (size.DimensionY + size.DimensionLength));
                if (canBePlaced)
                {
                    size.DimensionX = position.X;
                    size.DimensionY = position.Y;
                    break;
                }
            }
            return size;
        }
        public List<Layout> PackSizes(List<CustomerCartItem> sizes, List<Layout> layoutList)
        {
            var layout = new Layout()
            {
                Width = 0,
                Height = 0,
                Rects = new List<CustomerCartItem>()
            };
            var orderedSizes = Order(sizes);
            foreach (var size in orderedSizes)
            {
                var placedSize = FindBestPosition(layout, size);
                layout.Rects.Add(placedSize);
                
            }
            return layoutList;
        }
    }
    public class Layout
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public List<CustomerCartItem> Rects { get; set; }
    }
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
    public class Position
    {
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var serialized = JsonConvert.SerializeObject(self);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
