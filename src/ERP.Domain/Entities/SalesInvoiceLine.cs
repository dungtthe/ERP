using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class SalesInvoiceLine : Entity
    {
        public Guid SalesInvoiceId { get; set; }
        public Guid ProductVariantId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid? TaxId { get; set; }
        public decimal TaxRate { get; set; }  
    }
}
