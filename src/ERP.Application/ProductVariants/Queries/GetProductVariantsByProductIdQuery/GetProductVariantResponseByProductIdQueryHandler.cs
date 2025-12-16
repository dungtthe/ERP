using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.ProductVariants.Queries.GetProductVariantsByProductIdQuery
{
    public class GetProductVariantResponseByProductIdQueryHandler : IQueryHandler<GetProductVariantResponseByProductIdQuery, List<ProductVariantByProductIdResponse>>
    {
        private readonly IReadAppDbContext _readAppDbContext;

        public GetProductVariantResponseByProductIdQueryHandler(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }

        public async Task<Result<List<ProductVariantByProductIdResponse>>> Handle(GetProductVariantResponseByProductIdQuery request, CancellationToken cancellationToken)
        {
            if (request.productId == Guid.Empty)
            {
                return Result.Failure<List<ProductVariantByProductIdResponse>>(DomainErrors.Id.Empty);
            }
            var productVariants = await _readAppDbContext.ProductVariants
                                    .Where(p => p.ProductId == request.productId)
                                    .ToListAsync();

            var response = productVariants.Select(p => new ProductVariantByProductIdResponse
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return Result.Success(response);
        }
    }
}