using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Application.Helpers.Paginations;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.ProductVariants.Queries.GetProductVariants
{
    public class GetProductVariantsQueryHandler : IQueryHandler<GetProductVariantsQuery, PagedList<ProductVariantResponse>>
    {
        private readonly IReadAppDbContext _readAppDbContext;

        public GetProductVariantsQueryHandler(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }
        public async Task<Result<PagedList<ProductVariantResponse>>> Handle(GetProductVariantsQuery request, CancellationToken cancellationToken)
        {
            var query = _readAppDbContext.ProductVariants
                                .Include(x => x.Product)
                                .OrderByDescending(x => x.ProductId)
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(term));
            }

            var responseQuery = query.Select(c => new ProductVariantResponse
            {
                ProductVariantId = c.Id,
                ProductVariantName = c.Name,
                ProductVariantCode = c.SKU,
                ProductVariantImage = c.Images.FirstOrDefault(),
                ProductVariantType = c.Product.ProductType,
            });

            var pagedResult = await PagedList<ProductVariantResponse>.CreateAsync(
               responseQuery,
               request.Page,
               request.PageSize,
               cancellationToken);
            return pagedResult;
        }
    }
}