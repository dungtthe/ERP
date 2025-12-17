using ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Products.Queries.GetProductGeneralInfoById
{
    public record ProductGeneralInfoRespone
    (
        Guid Id,
        string Name,
        string Code,
        string Description,
        List<string> Images,
        Guid UnitOfMeasureId,
        ProductType ProductType,
        bool CanBeSold,
        bool CanBePurchased,
        bool CanBeManufactured,
        decimal PriceReference,
        decimal CostPrice,
        List<Guid> CategoryIds
    );
}
