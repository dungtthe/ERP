using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.Categories.Queries.GetLeafCategories
{
    public record LeafCategoryResponse
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public byte SortOrder { get; init; }
    }
}