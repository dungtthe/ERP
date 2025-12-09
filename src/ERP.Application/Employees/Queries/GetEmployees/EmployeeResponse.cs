using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.Employees.Queries.GetEmployees
{
    public record EmployeeResponse
    {
        public Guid Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Gender { get; init; }
        public decimal? Salary { get; init; }
        public string? Email { get; init; }
        public string? AvatarUrl { get; init; }
        public string? Position { get; init; }
        public string? DepartmentName { get; init; }

    }
}