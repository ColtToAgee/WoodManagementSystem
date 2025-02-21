using Newtonsoft.Json;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.AlgorithmTest
{
    public class BinPackingAlgorithm
    {
        private int WhitespaceWeight = 1;
        private int SideLengthWeight = 2000000000;

        public bool Intersects(CustomerCartItem a, CustomerCartItem b)
        {
            return a.DimensionX < b.DimensionX + b.DimensionWidth
                && a.DimensionX + a.DimensionWidth > b.DimensionX
                && a.DimensionY < b.DimensionY + b.DimensionLength
                && a.DimensionY + a.DimensionLength > b.DimensionY;
        }

        public bool Validate(List<CustomerCartItem> rects, CustomerCartItem rect)
        {
            var a = rect;
            for (var i = 0; i < rects.Count(); i++)
            {
                var b = rects[i];
                if (Intersects(a, b))
                {
                    return false;
                }
            }
            return true;
        }

        public double WhiteSpace(Layout layout)
        {
            double whitespace = layout.Width * layout.Height;
            for (var i = 0; i < layout.Rects.Count(); i++)
            {
                var rect = layout.Rects[i];
                whitespace -= rect.DimensionWidth * rect.DimensionLength;
            }
            return whitespace;
        }

        public double Rate(Layout layout)
        {
            return (WhiteSpace(layout) * WhitespaceWeight) + (Math.Max(layout.Width, layout.Height) * SideLengthWeight);
        }

        public Bound FindBounds(List<CustomerCartItem> CustomerCartItem)
        {
            double width = 0;
            double height = 0;
            for (var i = 0; i < CustomerCartItem.Count(); i++)
            {
                var rect = CustomerCartItem[i];
                var right = rect.DimensionX + rect.DimensionWidth;
                var bottom = rect.DimensionY + rect.DimensionLength;
                if (right > width)
                {
                    width = right;
                }
                if (bottom > height)
                {
                    height = bottom;
                }
            }
            return new Bound(width, height);
        }

        public List<Position> FindPositions(Pattern pattern)
        {
            var positions = new List<Position>();
            for (var i = 0; i < pattern.Width; i++)
            {
                for(var j = 0; j < pattern.Height; j++)
                {
                    positions.Add(new Position(i, j));
                }
            }
            return positions;
        }
        public CustomerCartItem FindBestRect(Layout layout, CustomerCartItem size, Pattern pattern)
        {
            var bestRect = size.DeepCopy();
            bestRect.DimensionX = 0;
            bestRect.DimensionY = 0;
            if (layout.Rects.Count() == 0)
            {
                return bestRect;
            }
            var rect = new CustomerCartItem();
            rect = size;
            rect.DimensionX = 0;
            rect.DimensionY = 0;
            var sandBox = new Layout()
            {
                Width = 0,
                Height = 0,
                Rects = layout.Rects.DeepCopy(),
            };
            var bestScore = double.PositiveInfinity;
            var positions = FindPositions(pattern);
            for (var i = 0; i < positions.Count(); i++)
            {
                var pos = positions[i];
                rect.DimensionX = pos.X;
                rect.DimensionY = pos.Y;
                if (Validate(layout.Rects, rect))
                {
                    if (sandBox.Rects.Count() == layout.Rects.Count())
                    {
                        sandBox.Rects.Add(rect);
                    }
                    else
                    {
                        sandBox.Rects[layout.Rects.Count()] = rect;
                    }

                    var size2 = FindBounds(sandBox.Rects);
                    sandBox.Width = size2.Width;
                    sandBox.Height = size2.Height;
                    var score = Rate(sandBox);
                    if (score < bestScore)
                    {
                        bestScore = score;
                        bestRect.DimensionX = rect.DimensionX;
                        bestRect.DimensionY = rect.DimensionY;
                    }
                }
            }
            return bestRect;
        }
        public List<int> PreOrder(List<CustomerCartItem> sizes)
        {
            var order = new List<int>();
            order = Enumerable.Range(0, sizes.Count()).ToList();
            order.Sort((a, b) => { return (int)(sizes[b].DimensionWidth * sizes[b].DimensionLength - sizes[a].DimensionWidth * sizes[a].DimensionLength); });
            return order;
        }
        public Layout ReOrder(Layout layout, List<int> order)
        {
            for (var i = 0; i < layout.Rects.Count(); i++)
            {
                (layout.Rects[i], layout.Rects[order[i]]) = (layout.Rects[order[i]], layout.Rects[i]);
            }
            return layout;
        }
        public CustomerCartItem CheckEdgeBand(CustomerCartItem size)
        {
            var edgeBandArray = size.EdgeBand.ToCharArray();
            if (edgeBandArray[0] == '4')
            {
                size.DimensionLength += 1.5;
            }
            if (edgeBandArray[1] == '4')
            {
                size.DimensionLength += 1.5;
            }
            if (edgeBandArray[2] == '4')
            {
                size.DimensionWidth += 1.5;
            }
            if (edgeBandArray[3] == '4')
            {
                size.DimensionWidth += 1.5;
            }
            return size;
        }
        public List<CustomerCartItem> FindEmptySpaces(Layout layout)
        {
            var emptySpaces = new List<CustomerCartItem>();

            // Layout'un tamamında boşluklar oluşturmak için bir 2D alan modellemesi yapıyoruz
            int layoutWidth = (int)Math.Ceiling(layout.Width);  // Genişliği int'e çevir
            int layoutHeight = (int)Math.Ceiling(layout.Height); // Yüksekliği int'e çevir

            // Layout üzerinde her bir hücreyi kontrol ediyoruz ve boş alanları CustomerCartItem olarak ekliyoruz
            var filledSpaces = new bool[layoutWidth, layoutHeight];

            // Tüm yerleştirilmiş CustomerCartItem'lar üzerinde döngü
            foreach (var rect in layout.Rects)
            {
                // Rectangle'ın alanını doldur
                int startX = (int)rect.DimensionX;
                int startY = (int)rect.DimensionY;
                int endX = (int)(rect.DimensionX + rect.DimensionWidth);
                int endY = (int)(rect.DimensionY + rect.DimensionLength);

                // Eğer sağlanan alan boyutları layout'un boyutları dışında kalıyorsa sınırları kontrol et
                for (int x = startX; x < endX; x++)
                {
                    for (int y = startY; y < endY; y++)
                    {
                        // Burada dizinin sınırlarını kontrol ediyoruz
                        if (x >= 0 && x < layoutWidth && y >= 0 && y < layoutHeight)
                        {
                            filledSpaces[x, y] = true; // Bu alanda bir öğe var, bu yüzden bu hücreyi "dolduruyoruz"
                        }
                    }
                }
            }

            // Boş alanları tespit et
            for (int x = 0; x < layoutWidth; x++)
            {
                for (int y = 0; y < layoutHeight; y++)
                {
                    if (!filledSpaces[x, y]) // Eğer bu hücre boşsa
                    {
                        // Yeni boş alan oluştur
                        var emptySpace = new CustomerCartItem
                        {
                            DimensionX = x,
                            DimensionY = y,
                            DimensionWidth = 1, // Başlangıç olarak her bir boşluk 1x1 kabul edebiliriz
                            DimensionLength = 1 // Burada boşlukların uzunluğu hesaplanabilir
                        };

                        // Boşlukların birleşmesini sağlamak için daha fazla kod eklenebilir
                        // Bu basit versiyonda, yalnızca her bir boş hücreyi ayrı bir boş alan olarak kabul ediyoruz.
                        emptySpaces.Add(emptySpace);
                    }
                }
            }

            return emptySpaces;
        }

        public List<Layout> Pack(List<CustomerCartItem> sizes, Pattern pattern, List<Layout> layoutList)
        {
            if (sizes.Count == 0) return layoutList;

            var layout = new Layout
            {
                Width = 0,
                Height = 0,
                Rects = new List<CustomerCartItem>()
            };

            var order = PreOrder(sizes);
            foreach (var index in order)
            {
                var item = sizes[index];

                if (!TryPlaceItem(layout, item, pattern))
                {
                    // Eğer normal yerleştirme başarısızsa, 90 derece döndürmeyi dene
                    (item.DimensionWidth, item.DimensionLength) = (item.DimensionLength, item.DimensionWidth);
                    if (!TryPlaceItem(layout, item, pattern))
                    {
                        // Eğer döndürerek de yerleştirilemiyorsa eski haline getir ve devam et
                        (item.DimensionWidth, item.DimensionLength) = (item.DimensionLength, item.DimensionWidth);
                    }
                }
            }

            layout.Width = layout.Rects.Max(r => r.DimensionX + r.DimensionWidth);
            layout.Height = layout.Rects.Max(r => r.DimensionY + r.DimensionLength);

            layout = ReOrder(layout, PreOrder(layout.Rects));
            layoutList.Add(layout);

            var remainingSizes = sizes.Where(size => !layout.Rects.Any(rect => rect.Id == size.Id)).ToList();
            if (remainingSizes.Count > 0)
                Pack(remainingSizes, pattern, layoutList);

            return layoutList;
        }

        // Belirtilen item'i layout'a eklemeye çalışır, başarı durumunu döndürür
        private bool TryPlaceItem(Layout layout, CustomerCartItem item, Pattern pattern)
        {
            var rect = FindBestRect(layout, item, pattern);
            if (rect == null) return false;

            layout.Rects.Add(rect);
            var bounds = FindBounds(layout.Rects);

            if (bounds.Width > pattern.Width || bounds.Height > pattern.Height)
            {
                layout.Rects.RemoveAt(layout.Rects.Count - 1);
                return false;
            }
            return true;
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
