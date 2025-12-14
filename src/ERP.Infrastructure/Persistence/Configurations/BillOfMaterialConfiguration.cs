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
    public class BillOfMaterialConfiguration : IEntityTypeConfiguration<BillOfMaterial>
    {
        public void Configure(EntityTypeBuilder<BillOfMaterial> builder)
        {
            builder.ToTable("bill_of_materials");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.ProductId)
                .HasColumnName("product_id");

            builder.Property(x => x.ProductVariantId)
              .HasColumnName("product_variant_id");

            builder.Property(x => x.Version)
                .HasColumnName("version");

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_bom_product");

            builder.HasOne(x => x.ProductVariant)
               .WithMany()
               .HasForeignKey(x => x.ProductVariantId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("fk_bom_product_variant");
        }
    }
}
