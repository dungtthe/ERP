using ERP.Application.Abstractions.Messaging;
using ERP.Application.Helpers.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : BasePaginationParameter, IQuery<PagedList<UserRespone>>
    {
    }

}
