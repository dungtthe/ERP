using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class Routing:Entity
    {
        public Routing(Guid id):base(id) { }
        public Guid BillOfMaterialId { get; set; }
        public BillOfMaterial BillOfMaterial { get; set; }
        public byte Version { get; set; }
        public string Note { get; set; }
    }
}
