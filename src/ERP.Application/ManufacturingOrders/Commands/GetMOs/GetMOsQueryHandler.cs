using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Application.Helpers.Paginations;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.ManufacturingOrders.Commands.GetMOs
{
    public class GetMOsQueryHandler : IQueryHandler<GetMOsQuery, PagedList<MOResponse>>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetMOsQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<PagedList<MOResponse>>> Handle(GetMOsQuery request, CancellationToken cancellationToken)
        {
            var query = _readDbContext.ManufacturingOrders
                            .Include(x => x.Routing)
                            .ThenInclude(x => x.BillOfMaterial)
                            .ThenInclude(x => x.ProductVariant)
                            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                query = query.Where(c => c.Code.ToLower().Contains(term));
            }

            var responseQuery = query.Select(c => new MOResponse
            {
                Id = c.Id,
                Code = c.Code,
                ProductName = c.Routing.BillOfMaterial.ProductVariant.Name,
                QuantityToProduce = c.QuantityToProduce,
                QuantityProduced = c.QuantityProduced,
                Status = c.ManufacturingOrderStatus,
            });

            var pagedResult = await PagedList<MOResponse>.CreateAsync(
                responseQuery,
                request.Page,
                request.PageSize,
                cancellationToken);

            return pagedResult;
        }
    }
}