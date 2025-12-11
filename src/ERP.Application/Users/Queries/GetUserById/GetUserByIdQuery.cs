using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery(Guid Id) : IQuery<UserByIdResponse>
    {
        public Guid Id { get; } = Id;
    }


}