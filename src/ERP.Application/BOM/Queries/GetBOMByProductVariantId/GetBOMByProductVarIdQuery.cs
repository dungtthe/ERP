using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.BOM.Queries.GetBOMByProductVariantId
{
    public class GetBOMByProductVarIdQuery(Guid ProductVariantId) : IQuery<BOMByProductVarIdResponse>
    {
        public Guid productVariantId { get; } = ProductVariantId;

    }
}