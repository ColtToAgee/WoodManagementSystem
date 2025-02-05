using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        public List<Position> FindPositions(List<CustomerCartItem> CustomerCartItem)
        {
            var positions = new List<Position>();
            for (var i = 0; i < CustomerCartItem.Count(); i++)
            {
                var rect = CustomerCartItem[i];
                for (var x = 0; x < rect.DimensionWidth; x++)
                {
                    positions.Add(new Position(rect.DimensionX + x, rect.DimensionY + rect.DimensionLength));
                }
                for (var y = 0; y < rect.DimensionLength; y++)
                {
                    positions.Add(new Position(rect.DimensionX + rect.DimensionWidth, rect.DimensionY + y));
                }
            }
            return positions;
        }
        public CustomerCartItem FindBestRect(Layout layout, CustomerCartItem size)
        {
            var bestRect = new CustomerCartItem();
            bestRect.DimensionWidth = size.DimensionWidth;
            bestRect.DimensionLength = size.DimensionLength;
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
                Rects = layout.Rects.Slice(0, layout.Rects.Count()),
            };
            var bestScore = double.PositiveInfinity;
            var positions = FindPositions(layout.Rects);
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
        public List<Layout> Pack(List<CustomerCartItem> sizes, Pattern pattern, List<Layout> layoutList)
        {
            var layout = new Layout()
            {
                Width = 0,
                Height = 0,
                Rects = new List<CustomerCartItem>()
            };
            if (sizes.Count() == 0)
            {
                return layoutList;
            }
            for (var i = 0; i < sizes.Count(); i++)
            {
                if (sizes[i].EdgeBand != "0000")
                {
                    var tempSize = CheckEdgeBand(sizes[i]);
                    sizes[i] = tempSize;
                }
            }
            var order = PreOrder(sizes);
            for (var i = 0; i < sizes.Count(); i++)
            {
                var originalSize = sizes[order[i]];


                // Hem normal hem de döndürülmüş haliyle en iyi yerleşimi bul
                var rectNormal = FindBestRect(layout, originalSize);

                (originalSize.DimensionWidth, originalSize.DimensionLength) = (originalSize.DimensionLength, originalSize.DimensionWidth);
                var rectRotated = FindBestRect(layout, originalSize);

                // Test için geçici layout'lar oluştur
                var layoutNormal = layout.DeepCopy();
                layoutNormal.Rects.Add(rectNormal);
                var scoreNormal = Rate(layoutNormal);

                var layoutRotated = layout.DeepCopy();
                layoutRotated.Rects.Add(rectRotated);
                var scoreRotated = Rate(layoutRotated);

                // En iyi skoru seç
                var bestRect = scoreRotated < scoreNormal ? rectRotated : rectNormal;

                layout.Rects.Add(bestRect);

                var bounds = FindBounds(layout.Rects);
                if (pattern.Width < bounds.Width || pattern.Height < bounds.Height)
                {
                    var tempSizes = new List<CustomerCartItem>();
                    for (int j = 0; j < order.Count() - i; j++)
                    {
                        tempSizes.Add(sizes[order[j + i]]);
                    }
                    layout.Rects.RemoveAt(layout.Rects.Count() - 1);
                    Pack(tempSizes, pattern, layoutList);
                    break;
                }
                layout.Width = bounds.Width;
                layout.Height = bounds.Height;
            }
            order = PreOrder(layout.Rects);
            layout = ReOrder(layout, order);
            layoutList.Add(layout);
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
