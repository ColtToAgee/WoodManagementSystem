using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Domain.Common;

namespace WoodManagementSystem.Domain.Entities
{
    public class Pattern:EntityBase,IEntityBase
    {
        public double Width { get; set; }
        public double Height { get; set; } 
        public int Quantity { get; set; }
        public double Cost { get; set; }
    }
}
