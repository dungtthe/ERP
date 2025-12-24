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
    public class PurchaseInvoiceConfiguration : IEntityTypeConfiguration<PurchaseInvoice>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
        {
            builder.ToTable("purchase_invoices");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("invoice_number");

            builder.Property(x => x.SupplierId).HasColumnName("supplier_id");
            builder.Property(x => x.InvoiceDate).HasColumnName("invoice_date");
            builder.Property(x => x.DueDate).HasColumnName("due_date");

            builder.HasOne(x => x.Supplier)
                .WithMany()
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_pi_supplier");
        }
    }

}
