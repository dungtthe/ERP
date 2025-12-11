using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class RoutingStep:Entity
    {
        public RoutingStep(Guid id): base(id) { }
        public Guid RoutingId { get; set; }
        public Routing Routing { get; set; }
        public byte StepOrder { get; set; }
        public string OperationName { get; set; }
        public double OperationTime { get; set; }
        public List<string> Images { get; set; } = new();
        public string Note {  get; set; }
    }
}
