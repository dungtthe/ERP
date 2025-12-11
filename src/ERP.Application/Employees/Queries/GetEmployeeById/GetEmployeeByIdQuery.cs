using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery(Guid Id) : IQuery<EmployeeByIdResponse>
    {
        public Guid Id { get; } = Id;
    }
}