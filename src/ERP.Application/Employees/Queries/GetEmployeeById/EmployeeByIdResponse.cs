using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.Employees.Queries.GetEmployeeById
{
    public record EmployeeByIdResponse
    {
        public Guid Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Position { get; init; }
        public DateTime? HireDate { get; init; }
        public DateTime? DateOfBirth { get; init; }
        public string? Status { get; init; }
        public string? Gender { get; init; }
        public decimal? Salary { get; init; }
        public string? DepartmentName { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Address { get; init; }
        public string? AvatarUrl { get; init; }
        public string? Email { get; init; }
        public string? Password { get; init; }
        public Boolean? IsLock { get; init; }
    }
}