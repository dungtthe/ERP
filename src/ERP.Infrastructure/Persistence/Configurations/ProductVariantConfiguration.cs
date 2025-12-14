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
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("product_variants");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.ProductId).HasColumnName("product_id");

            builder.Property(x => x.SKU)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sku");

            builder.HasIndex(x => x.SKU).IsUnique().HasDatabaseName("ux_product_variants_sku");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");

            builder.Property(x => x.Images)
                .HasColumnType("text[]")
                .HasColumnName("images");

            builder.Property(x => x.PriceReference)
                .HasColumnType("numeric(18,4)")
                .HasColumnName("price_reference");

            builder.Property(x => x.CostPrice)
                .HasColumnType("numeric(18,4)")
                .HasColumnName("cost_price");


            builder.Property(x => x.Weight).HasColumnName("weight").HasColumnType("numeric(18,4)");
            builder.Property(x => x.Length).HasColumnName("length").HasColumnType("numeric(18,4)");
            builder.Property(x => x.Width).HasColumnName("width").HasColumnType("numeric(18,4)");
            builder.Property(x => x.Height).HasColumnName("height").HasColumnType("numeric(18,4)");
            builder.Property(x => x.Volume).HasColumnName("volume").HasColumnType("numeric(18,4)");

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_product_variants_product");
        }
    }
}
