using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.ProductVariants.Queries.GetProductVariantsByProductIdQuery
{
    public record ProductVariantByProductIdResponse
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }

    }
}