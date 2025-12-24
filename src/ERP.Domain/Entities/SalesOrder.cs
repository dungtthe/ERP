using ERP.Domain.Enums;
using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class SalesOrder : AggregateRoot
    {
        public string Code { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public SalesOrderStatus Status { get; set; }

        private readonly List<SalesOrderLine> _salesOrderLine = new();
        public IReadOnlyCollection<SalesOrderLine> SalesOrderLines => _salesOrderLine;

        public SalesInvoice? SalesInvoice { get; private set; }
    }

}
