using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Application.Helpers.Paginations;
using ERP.Application.Users.Queries.GetCustomers;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, PagedList<CustomerResponse>>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetCustomersQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<PagedList<CustomerResponse>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var query = _readDbContext.Customers
                            .Include(c => c.User)
                            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                query = query.Where(c => c.CompanyName.ToLower().Contains(term));
            }

            var responseQuery = query.Select(c => new CustomerResponse
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                Email = c.User!.Email,
                PhoneNumber = c.User.PhoneNumber,
                Address = c.User.Address,
                AvatarUrl = c.User.AvatarUrl
            });

            var pagedResult = await PagedList<CustomerResponse>.CreateAsync(
                responseQuery,
                request.Page,
                request.PageSize,
                cancellationToken);

            return pagedResult;
        }
    }
}
