using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.ProductVariants.Queries.GetBOMByProductVariantId
{
    public class GetBOMByProductVarIdQuery(Guid ProductVariantId) : IQuery<BOMByProductVarIdResponse>
    {
        public Guid productVariantId { get; } = ProductVariantId;

    }
}