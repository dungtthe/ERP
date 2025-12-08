using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.GetUsers
{
    public record UserRespone
    {
        public Guid Id { get; init; }
        public string? Username { get; init; }
    }
}
