using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.ProductVariants.Commands.CreateProductVariant
{
    public record CreateProductVariantCommand(
    Guid ProductId,
    string? SKU,
    string? Name,
    List<string>? Images,
    decimal? PriceReference,
    decimal? CostPrice,
    int? Weight,
    int? Length,
    int? Width,
    int? Height,
    int? Volume) : ICommand<Guid>;
}