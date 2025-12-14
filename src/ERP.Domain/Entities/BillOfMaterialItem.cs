using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class BillOfMaterialItem:Entity
    {
        public BillOfMaterialItem(Guid id):base(id) { }
        public Guid BillOfMaterialId { get; set; }
        public BillOfMaterial BillOfMaterial { get; set; }
        public Guid MaterialId { get; set; }
        public ProductVariant Material { get; set; }
        public decimal QuantityRequired { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public List<Guid> ApplyToAttributeValueIds { get; set; } = new();
    }
}
