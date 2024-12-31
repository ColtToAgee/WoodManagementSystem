using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodManagementSystem.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryRequest:IRequest<IList<GetAllUsersQueryResponse>>
    {
    }
}
