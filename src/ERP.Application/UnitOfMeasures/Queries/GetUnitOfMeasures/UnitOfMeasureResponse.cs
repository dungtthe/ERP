using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Application.UnitOfMeasures.Queries.GetUnitOfMeasures
{
    public record UnitOfMeasureResponse
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
    }
}