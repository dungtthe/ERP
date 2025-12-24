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
    public class GoodsReceiptLineConfiguration : IEntityTypeConfiguration<GoodsReceiptLine>
    {
        public void Configure(EntityTypeBuilder<GoodsReceiptLine> builder)
        {
            builder.ToTable("goods_receipt_lines");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.GoodsReceiptId).HasColumnName("goods_receipt_id");
            builder.Property(x => x.ProductVariantId).HasColumnName("product_variant_id");
            builder.Property(x => x.Quantity)
                .HasColumnType("numeric(18,4)")
                .HasColumnName("quantity");

            builder.HasOne<GoodsReceipt>()
                .WithMany(nameof(GoodsReceipt.GoodsReceiptLines))
                .HasForeignKey(x => x.GoodsReceiptId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_grl_goods_receipt");

            builder.HasOne(x => x.ProductVariant)
                .WithMany()
                .HasForeignKey(x => x.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_grl_product_variant");
        }
    }

}
