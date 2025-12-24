using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class SalesInvoice : AggregateRoot
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }

        private readonly List<SalesInvoiceLine> _salesInvoiceLines = new();
        public IReadOnlyCollection<SalesInvoiceLine> SalesInvoiceLines => _salesInvoiceLines;

        public Guid SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
    }
}
