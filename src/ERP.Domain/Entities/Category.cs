using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public Guid ?ParentId { get; set; }
        public Category ?Parent { get; set; }
        public byte Level { get; set; }
        public byte SortOrder { get; set; }

        public Category(Guid id):base(id)
        {

        }
    }
}
