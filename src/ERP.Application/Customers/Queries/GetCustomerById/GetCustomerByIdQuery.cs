using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery(Guid Id) : IQuery<CustomerByIdResponse>
    {
        public Guid Id { get; } = Id;
    }


}