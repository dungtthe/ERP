using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Persistence.Configurations
{
    public class DeliveryOrderLineConfiguration : IEntityTypeConfiguration<DeliveryOrderLine>
    {
        public void Configure(EntityTypeBuilder<DeliveryOrderLine> builder)
        {
            builder.ToTable("delivery_order_lines");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.DeliveryOrderId).HasColumnName("delivery_order_id");
            builder.Property(x => x.ProductVariantId).HasColumnName("product_variant_id");
            builder.Property(x => x.Quantity)
                .HasColumnType("numeric(18,4)")
                .HasColumnName("quantity");

            builder.HasOne<DeliveryOrder>()
                .WithMany(nameof(DeliveryOrder.DeliveryOrderLines))
                .HasForeignKey(x => x.DeliveryOrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_dol_delivery_order");

            builder.HasOne(x => x.ProductVariant)
                .WithMany()
                .HasForeignKey(x => x.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dol_product_variant");
        }
    }

}
