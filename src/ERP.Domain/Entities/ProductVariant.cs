using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class ProductVariant : Entity
    {
        public ProductVariant(Guid id) : base(id)
        {
        }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public List<string> Images { get; set; } = new();
        public decimal ?PriceReference { get; set; }
        public decimal ?CostPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Volume { get; set; }
    }
}
