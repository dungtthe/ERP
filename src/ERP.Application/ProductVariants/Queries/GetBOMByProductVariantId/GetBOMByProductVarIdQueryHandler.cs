using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.ProductVariants.Queries.GetBOMByProductVariantId
{
    public class GetBOMByProductIdQueryHandler : IQueryHandler<GetBOMByProductVarIdQuery, BOMByProductVarIdResponse>
    {
        private readonly IReadAppDbContext _readAppDbContext;
        private readonly IProductVariantRepository _productVariantRepository;
        public GetBOMByProductIdQueryHandler(IReadAppDbContext readAppDbContext, IProductVariantRepository productVariantRepository)
        {
            _readAppDbContext = readAppDbContext;
            _productVariantRepository = productVariantRepository;
        }

        public async Task<Result<BOMByProductVarIdResponse>> Handle(GetBOMByProductVarIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _productVariantRepository.IsProductVariantExist(request.productVariantId))
            {
                return Result.Failure<BOMByProductVarIdResponse>(DomainErrors.ProductVariant.NotFound);
            }

            var bom = await _readAppDbContext.BillOfMaterials
                            .Include(x => x.ProductVariant)
                            .Where(x => x.ProductVariantId == request.productVariantId)
                            .OrderByDescending(x => x.Version)
                            .FirstOrDefaultAsync(cancellationToken);

            var bomItem = await _readAppDbContext.BillOfMaterialItems
                                   .Include(x => x.UnitOfMeasure)
                                   .Include(x => x.Material)
                                   .Where(x => x.BillOfMaterialId == bom.Id)
                                   .ToListAsync(cancellationToken);

            var result = new BOMByProductVarIdResponse
            {
                BOMId = bom.Id,
                BOMCode = "BOM-" + bom.ProductVariant.SKU + "-" + bom.Version,
                LatestVersion = bom.Version,
                ListMaterials = bomItem.Select(x => new Material
                {
                    Id = x.Id,
                    MaterialName = x.Material.Name,
                    QuantityRequired = x.QuantityRequired,
                    UnitOfMeasureName = x.UnitOfMeasure.Name
                }).ToList()
            };

            return Result.Success(result);
        }
    }
}