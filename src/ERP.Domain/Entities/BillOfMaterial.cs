using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class BillOfMaterial:Entity
    {
        public BillOfMaterial(Guid id):base(id) { }
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public byte Version { get; set; }
    }
}
