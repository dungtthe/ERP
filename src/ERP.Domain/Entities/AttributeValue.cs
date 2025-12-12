using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class AttributeValue:Entity
    {
        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; }
        public string Value { get; set; }

        public AttributeValue(Guid id):base(id) { }
    }
}
