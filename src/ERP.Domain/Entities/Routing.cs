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
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public string Version { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
