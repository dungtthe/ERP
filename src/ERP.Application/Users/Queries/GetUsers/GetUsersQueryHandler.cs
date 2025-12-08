using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Application.Helpers.Paginations;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, PagedList<UserRespone>>
    {
        private readonly IReadAppDbContext _readAppDbContext;
        public GetUsersQueryHandler(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }

        public async Task<Result<PagedList<UserRespone>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _readAppDbContext.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();
                query = query.Where(u => u.Email.Contains(term));
            }

            var responseQuery = query.Select(u => new UserRespone
            {
                Id = u.Id,
                Username = u.Email
            });

            var pagedResult = await PagedList<UserRespone>.CreateAsync(
                responseQuery,
                request.Page,
                request.PageSize,
                cancellationToken);

            return pagedResult;
        }
    }
}
