using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodManagementSystem.Application.DTOs
{
    public class TemplateCustomerCartDto
    {
        public int? Id { get; set; }
        public double? DimensionWidth { get; set; }
        public double? DimensionLength { get; set; }
        public string? EdgeBand { get; set; }
    }
}
