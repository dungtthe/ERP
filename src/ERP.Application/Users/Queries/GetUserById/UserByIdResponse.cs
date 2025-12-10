using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.GetUserById
{
    public record UserByIdResponse
    {
        public Guid Id { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Password { get; init; }
    }
}