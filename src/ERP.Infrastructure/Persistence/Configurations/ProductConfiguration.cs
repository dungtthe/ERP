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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("code");

            builder.HasIndex(x => x.Code).IsUnique().HasDatabaseName("ux_products_code");

            builder.Property(x => x.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");

            builder.Property(x => x.Images)
                .HasColumnType("text[]")
                .HasColumnName("images");

            builder.Property(x => x.UnitOfMeasureId)
                .HasColumnName("unit_of_measure_id");

            builder.Property(x => x.ProductType)
                .HasColumnName("product_type")
                .HasConversion<byte>();

            builder.Property(x => x.CanBeSold).HasColumnName("can_be_sold");
            builder.Property(x => x.CanBePurchased).HasColumnName("can_be_purchased");
            builder.Property(x => x.CanBeManufactured).HasColumnName("can_be_manufactured");

            builder.HasOne(x => x.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(x => x.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_products_uom");
        }
    }
}
