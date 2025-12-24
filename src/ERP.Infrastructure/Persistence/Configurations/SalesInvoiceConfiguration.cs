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
    public class SalesInvoiceConfiguration : IEntityTypeConfiguration<SalesInvoice>
    {
        public void Configure(EntityTypeBuilder<SalesInvoice> builder)
        {
            builder.ToTable("sales_invoices");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("invoice_number");

            builder.Property(x => x.SalesOrderId)
                .HasColumnName("sales_order_id");

            builder.Property(x => x.InvoiceDate)
                .HasColumnName("invoice_date");

            builder.Property(x => x.DueDate)
                .HasColumnName("due_date");

            builder.HasOne(x => x.SalesOrder)
                .WithOne(x => x.SalesInvoice)
                .HasForeignKey<SalesInvoice>(x => x.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sales_invoices_sales_order");

            builder.HasIndex(x => x.SalesOrderId)
                .IsUnique()
                .HasDatabaseName("ux_sales_invoices_sales_order");
        }
    }

}
