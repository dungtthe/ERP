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
    public class SalesInvoiceLineConfiguration : IEntityTypeConfiguration<SalesInvoiceLine>
    {
        public void Configure(EntityTypeBuilder<SalesInvoiceLine> builder)
        {
            builder.ToTable("sales_invoice_lines");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.SalesInvoiceId)
                .HasColumnName("sales_invoice_id");

            builder.Property(x => x.ProductVariantId)
                .HasColumnName("product_variant_id");

            builder.Property(x => x.Quantity)
                .HasColumnType("numeric(18,4)")
                .HasColumnName("quantity");

            builder.Property(x => x.UnitPrice)
                .HasColumnType("numeric(18,4)")
                .HasColumnName("unit_price");

            builder.Property(x => x.TaxRate)
                .HasColumnType("numeric(5,4)")
                .HasColumnName("tax_rate");

            builder.Property(x => x.TaxId)
                .HasColumnName("tax_id");

            builder.HasOne<SalesInvoice>()
                .WithMany(nameof(SalesInvoice.SalesInvoiceLines))
                .HasForeignKey(x => x.SalesInvoiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_sil_sales_invoice");

            builder.HasOne(x => x.ProductVariant)
                .WithMany()
                .HasForeignKey(x => x.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sil_product_variant");

            builder.HasOne(x => x.Tax)
                .WithMany()
                .HasForeignKey(x => x.TaxId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sil_tax");
        }
    }

}
