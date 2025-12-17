using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class BillOfMaterial : Entity
    {
        public BillOfMaterial(Guid id) : base(id) { }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

        public byte Version { get; set; }
        private BillOfMaterial(
            Guid id,
            Guid productId,
            Guid? productVariantId,
            byte version)
            : base(id)
        {
            ProductId = productId;
            ProductVariantId = productVariantId;
            Version = version;
        }


        public static BillOfMaterial Create(
            Guid productId,
            Guid? productVariantId,
            byte version)
        {

            return new BillOfMaterial(
                Guid.NewGuid(),
                productId,
                productVariantId,
                version
               );
        }
    }
}
