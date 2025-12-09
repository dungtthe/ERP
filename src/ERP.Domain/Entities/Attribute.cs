using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class Attribute:Entity
    {
        public Attribute(Guid id, string name) : base(id)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
