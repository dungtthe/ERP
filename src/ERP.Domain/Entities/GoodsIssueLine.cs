using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class GoodsIssueLine : Entity
    {
        public Guid GoodsIssueId { get; set; }
        public Guid ProductVariantId { get; set; }
        public decimal Quantity { get; set; }
    }

}
