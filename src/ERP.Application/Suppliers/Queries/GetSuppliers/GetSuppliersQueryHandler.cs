using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Application.Helpers.Paginations;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Suppliers.Queries.GetSuppliers
{
    public class GetSuppliersQueryHandler : IQueryHandler<GetSuppliersQuery, PagedList<SupplierResponse>>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetSuppliersQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<PagedList<SupplierResponse>>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var query = _readDbContext.Suppliers
                            .Include(c => c.User)
                            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                query = query.Where(c => c.CompanyName.ToLower().Contains(term));
            }

            var responseQuery = query.Select(c => new SupplierResponse
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                Email = c.User!.Email,
                PhoneNumber = c.User.PhoneNumber,
                Address = c.User.Address,
                AvatarUrl = c.User.AvatarUrl
            });

            var pagedResult = await PagedList<SupplierResponse>.CreateAsync(
                responseQuery,
                request.Page,
                request.PageSize,
                cancellationToken);

            return pagedResult;
        }
    }
}