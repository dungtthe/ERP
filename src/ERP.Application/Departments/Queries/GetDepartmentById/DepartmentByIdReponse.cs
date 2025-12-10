using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.Departments.Queries.GetDepartmentById
{
    public record DepartmentByIdReponse
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
    }
}