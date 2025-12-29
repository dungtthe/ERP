using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class WorkOrder : Entity
    {

        public WorkOrder(Guid id) : base(id) { }

        public Guid ManufacturingOrderId { get; set; }
        public ManufacturingOrder ManufacturingOrder { get; set; }
        public Guid WorkCenterId { get; set; }
        public WorkCenter WorkCenter { get; set; }
        public Guid RoutingStepId { get; set; }
        public RoutingStep RoutingStep { get; set; }
        private WorkOrder(Guid id, Guid manufacturingOrderId, Guid workCenterId, Guid routingStepId) : base(id)
        {
            ManufacturingOrderId = manufacturingOrderId;
            WorkCenterId = workCenterId;
            RoutingStepId = routingStepId;
        }
        public static WorkOrder Create(Guid manufacturingOrderId, Guid workCenterId, Guid routingStepId)
        {
            return new WorkOrder(Guid.NewGuid(), manufacturingOrderId, workCenterId, routingStepId);
        }
    }
}
