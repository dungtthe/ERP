using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class ProductCatergory
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
