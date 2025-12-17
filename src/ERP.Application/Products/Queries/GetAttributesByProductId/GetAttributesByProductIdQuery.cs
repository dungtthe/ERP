
using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.Products.Queries.GetAttributesByProductId
{
    public class GetAttributesByProductIdQuery(Guid productId) : IQuery<List<AttributesByProductIdResponse>>
    {
        public Guid productId { get; } = productId;

    }
}