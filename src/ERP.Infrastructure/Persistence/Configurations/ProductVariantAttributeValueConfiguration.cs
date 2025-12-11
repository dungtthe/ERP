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
    public class ProductVariantAttributeValueConfiguration : IEntityTypeConfiguration<ProductVariantAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductVariantAttributeValue> builder)
        {
            builder.ToTable("product_variant_attribute_values");

            builder.HasKey(x => new { x.ProductVariantId, x.AttributeValueId });

            builder.Property(x => x.ProductVariantId).HasColumnName("product_variant_id");
            builder.Property(x => x.AttributeValueId).HasColumnName("attribute_value_id");

            builder.HasOne(x => x.ProductVariant)
                .WithMany()
                .HasForeignKey(x => x.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_pvav_product_variant");

            builder.HasOne(x => x.AttributeValue)
                .WithMany()
                .HasForeignKey(x => x.AttributeValueId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_pvav_attribute_value");
        }
    }
}
