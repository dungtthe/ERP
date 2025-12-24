using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class DeliveryOrder : AggregateRoot
    {
        public string Code { get; set; }
        public Guid SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public DateTime DeliveryDate { get; set; }

        private readonly List<DeliveryOrderLine> _deliveryOrderLines = new();
        public IReadOnlyCollection<DeliveryOrderLine> DeliveryOrderLines=> _deliveryOrderLines;
    }

}
