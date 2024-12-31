using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Carts.Queries.GetTemplateCustomerCart
{
    public class GetTemplateCustomerCartQueryResponse
    {
        public List<Layout> LayoutList { get; set; }
    }
}
