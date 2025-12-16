using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.ProductVariants.Queries.GetProductVariantSummaries
{
    public record ProductVariantSummaryResponse
    {
        public Guid Id { get; init; }
        public string? SKU { get; init; }
        public string? Name { get; init; }
    }
}