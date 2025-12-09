using ERP.Domain.Enums;
using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class ManufacturingOrder:Entity
    {
        public ManufacturingOrder(Guid id):base(id) { }
        public string Code { get; set; }
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public int QuantityToProduce { get; set; }
        public int QuantityProduced { get; set; }
        public Guid BillOfMaterialId { get; set; }
        public BillOfMaterial BillOfMaterial { get; set; }
        public Guid RoutingId { get; set; }
        public Routing Routing { get; set; }
        public ManufacturingOrderStatus ManufacturingOrderStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
