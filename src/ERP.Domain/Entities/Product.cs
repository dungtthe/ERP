using ERP.Domain.Enums;
using ERP.Domain.Errors;
using ERP.Domain.Primitives;
using ERP.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class Product:AggregateRoot
    {
        public Product(Guid id):base(id)
        {
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; } = new();
        public Guid UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public ProductType ProductType { get; set; }
        public bool CanBeSold { get; set; }
        public bool CanBePurchased { get; set; }
        public bool CanBeManufactured { get; set; }
        public decimal PriceReference { get; set; }
        public decimal CostPrice { get; set; }

        private readonly List<ProductVariant> _variants = new();
        public IReadOnlyCollection<ProductVariant> Variants => _variants.AsReadOnly();

        public Result AddVariant(ProductVariant variant)
        {
            if (_variants.Any(x => x.SKU == variant.SKU))
            {
                return Result.Failure(DomainErrors.Product.SkuAlreadyExists);
            }
            _variants.Add(variant);
            return Result.Success();
        }

        public string GenerateSKU()
        {
            //tam thoi nhu nay
            return this.Code + _variants.Count.ToString();
        }
    }
}
