using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserRespone>>
    {
        private readonly IReadAppDbContext _readAppDbContext;
        public GetUsersQueryHandler(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }

        public async Task<Result<List<UserRespone>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var rs = await _readAppDbContext.Users.ToListAsync(cancellationToken);
            var users = rs.Select(u => new UserRespone
            {
                Id = u.Id,
                Username = u.Username
            }).ToList();

            return users;
        }
    }
}
