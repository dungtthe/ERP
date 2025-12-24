using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class SalesOrderLine : Entity
    {
        public Guid SalesOrderId { get; set; }
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid ?TaxId { get; set; }
        public Tax? Tax { get; set; }
        public decimal TaxRate { get; set; }
    }
}
