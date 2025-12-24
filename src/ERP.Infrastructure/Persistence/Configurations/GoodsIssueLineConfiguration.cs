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
    public class GoodsIssueLineConfiguration : IEntityTypeConfiguration<GoodsIssueLine>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueLine> builder)
        {
            builder.ToTable("goods_issue_lines");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.GoodsIssueId).HasColumnName("goods_issue_id");
            builder.Property(x => x.ProductVariantId).HasColumnName("product_variant_id");
            builder.Property(x => x.Quantity)
                .HasColumnType("numeric(18,4)")
                .HasColumnName("quantity");

            builder.HasOne<GoodsIssue>()
                .WithMany(nameof(GoodsIssue.GoodsIssueLines))
                .HasForeignKey(x => x.GoodsIssueId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_gil_goods_issue");

            builder.HasOne(x => x.ProductVariant)
                .WithMany()
                .HasForeignKey(x => x.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_gil_product_variant");
        }
    }

}
