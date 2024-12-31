using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.DTOs
{
    public class OrderDetailDto
    {
        public double DimensionWidth { get; set; }
        public double DimensionLength { get; set; }
        public string EdgeBand { get; set; }
        public int OrderId { get; set; }
    }
}
