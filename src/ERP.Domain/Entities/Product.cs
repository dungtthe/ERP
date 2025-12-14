using ERP.Domain.Enums;
using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class Product:Entity
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
    }
}
