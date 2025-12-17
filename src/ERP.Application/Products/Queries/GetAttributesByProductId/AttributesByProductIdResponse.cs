using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.Products.Queries.GetAttributesByProductId
{
    public record AttributesByProductIdResponse
    {
        public Guid AttributeId { get; init; }
        public string? Name { get; init; }
        public List<AttributeValue>? AttributeValue { get; init; }
    }
    public record AttributeValue
    {
        public Guid AttributeValueId { get; init; }
        public string? Value { get; init; }

    }
}