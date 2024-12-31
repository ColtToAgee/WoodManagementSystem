using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Domain.Common;

namespace WoodManagementSystem.Domain.Entities
{
    public class Pattern : EntityBase, IEntityBase
    {
        public Pattern()
        {
            
        }
        public Pattern(string patternName, double width, double height, double cost)
        {
            this.PatternName = patternName;
            this.Width = width;
            this.Height = height;
            this.Cost = cost;
        }
        public string PatternName { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Cost { get; set; }
    }
}
