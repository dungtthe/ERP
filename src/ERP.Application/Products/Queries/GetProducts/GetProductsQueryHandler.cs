using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Application.Helpers.Paginations;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, PagedList<ProductResponse>>
    {
        private readonly IReadAppDbContext _readAppDbContext;

        public GetProductsQueryHandler(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }

        public async Task<Result<PagedList<ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _readAppDbContext.Products
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(term));
            }

            var responseQuery = query.Select(c => new ProductResponse
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                Image = c.Images.FirstOrDefault(),
                ProductType = c.ProductType,
                CostPrice = c.CostPrice,
                ProductVariantNumber = _readAppDbContext.ProductVariants.Where(p => p.ProductId == c.Id).Count()
            });

            var pagedResult = await PagedList<ProductResponse>.CreateAsync(
                responseQuery,
                request.Page,
                request.PageSize,
                cancellationToken);
            return pagedResult;
        }
    }
}