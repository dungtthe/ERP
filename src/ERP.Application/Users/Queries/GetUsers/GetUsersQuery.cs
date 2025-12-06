using ERP.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.GetUsers
{
    public record GetUsersQuery():IQuery<List<UserRespone>>;

}
