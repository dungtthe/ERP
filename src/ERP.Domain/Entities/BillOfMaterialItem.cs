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
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public double QuantityRequired { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
