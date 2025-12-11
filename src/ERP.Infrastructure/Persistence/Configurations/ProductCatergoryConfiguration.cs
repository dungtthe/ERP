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
    public class ProductCatergoryConfiguration : IEntityTypeConfiguration<ProductCatergory>
    {
        public void Configure(EntityTypeBuilder<ProductCatergory> builder)
        {
            builder.ToTable("product_categories");

            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.Property(x => x.ProductId).HasColumnName("product_id");
            builder.Property(x => x.CategoryId).HasColumnName("category_id");

            builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_product_categories_product");

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_product_categories_category");

        }
    }
}
