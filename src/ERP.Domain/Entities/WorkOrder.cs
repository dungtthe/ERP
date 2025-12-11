using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class WorkOrder
    {
        public Guid ManufacturingOrderId { get; set; }
        public ManufacturingOrder ManufacturingOrder { get; set; }
        public Guid WorkCenterId { get; set; }
        public WorkCenter WorkCenter { get; set; }
        public Guid RoutingStepId { get; set; }
        public RoutingStep RoutingStep { get; set; }
    }
}
