using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodManagementSystem.Application.Features.Patterns.Queries.GetAllPatterns
{
    public class GetAllPatternsQueryResponse
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Cost { get; set; }
    }
}
