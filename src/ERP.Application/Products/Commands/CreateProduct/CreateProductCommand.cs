using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand
        (string? Name,
        string? Code,
        string? Description,
        List<string>? Images,
        Guid UnitOfMeasureId,
        ProductType ProductType,
        bool CanBeSold,
        bool CanBePurchased,
        bool CanBeManufactured,
        List<Guid>? CategoryIds) : ICommand<Guid>;
}
