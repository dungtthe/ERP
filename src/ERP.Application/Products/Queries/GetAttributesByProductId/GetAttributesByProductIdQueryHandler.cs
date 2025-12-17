
using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Products.Queries.GetAttributesByProductId
{
    public class GetAttributesByProductIdQueryHandler : IQueryHandler<GetAttributesByProductIdQuery, List<AttributesByProductIdResponse>>
    {
        private readonly IReadAppDbContext _readAppDbContext;
        private readonly IProductRepository _productRepository;

        public GetAttributesByProductIdQueryHandler(IReadAppDbContext readAppDbContext, IProductRepository productRepository)
        {
            _readAppDbContext = readAppDbContext;
            _productRepository = productRepository;
        }

        public async Task<Result<List<AttributesByProductIdResponse>>> Handle(GetAttributesByProductIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _productRepository.IsProductExist(request.productId))
            {
                return Result.Failure<List<AttributesByProductIdResponse>>(DomainErrors.Product.NotFound);

            }

            var attributeValues = await _readAppDbContext.ProductVariantAttributeValues
                                        .Where(x => x.ProductVariant.ProductId == request.productId)
                                        .Include(x => x.AttributeValue)
                                        .ThenInclude(a => a.Attribute)
                                        .ToListAsync(cancellationToken);

            var result = attributeValues.GroupBy(x => new
            {
                AttributeId = x.AttributeValue.Attribute.Id,
                AttributeName = x.AttributeValue.Attribute.Name
            }).Select(g => new AttributesByProductIdResponse
            {
                AttributeId = g.Key.AttributeId,
                Name = g.Key.AttributeName,
                AttributeValue = g
                    .Select(x => x.AttributeValue)
                    .GroupBy(av => av.Id)
                    .Select(avGroup => new AttributeValue
                    {
                        AttributeValueId = avGroup.Key,
                        Value = avGroup.First().Value
                    })
                    .ToList()
            }).ToList();
            return Result.Success(result);

        }
    }
}