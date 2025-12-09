using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class WorkCenter:Entity
    {
        public WorkCenter(Guid id):base(id) { }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostPerHour { get; set; }
    }
}
