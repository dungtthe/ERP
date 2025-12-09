using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.Customers.Queries.GetCustomerById
{
    public record CustomerByIdResponse
    {
        public Guid Id { get; init; }
        public string? CompanyName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Address { get; init; }
        public string? AvatarUrl { get; init; }
    }
}