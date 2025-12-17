using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.ProductVariants.Queries.GetProductVariantsByProductIdQuery
{
    public class GetProductVariantResponseByProductIdQuery(Guid productId) : IQuery<List<ProductVariantByProductIdResponse>>
    {
        public Guid productId { get; } = productId;
    }
}