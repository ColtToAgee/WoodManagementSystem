using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodManagementSystem.Application.Features.Orders.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersQueryRequest:IRequest<IList<GetCustomerOrdersQueryResponse>>
    {
        public int CustomerUserId { get; set; }
    }
}
