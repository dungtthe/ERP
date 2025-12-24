using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class PurchaseInvoice : AggregateRoot
    {
        public string InvoiceNumber { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }

        private readonly List<PurchaseInvoiceLine> _purchaseInvoiceLine = new();
        public IReadOnlyCollection<PurchaseInvoiceLine> PurchaseInvoiceLines => _purchaseInvoiceLine;
    }

}
