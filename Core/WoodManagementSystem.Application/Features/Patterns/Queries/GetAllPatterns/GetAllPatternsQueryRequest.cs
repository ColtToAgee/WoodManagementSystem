using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodManagementSystem.Application.Features.Patterns.Queries.GetAllPatterns
{
    public class GetAllPatternsQueryRequest:IRequest<IList<GetAllPatternsQueryResponse>>
    {
    }
}
