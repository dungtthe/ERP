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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payments");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Amount)
                .HasColumnType("numeric(18,4)")
                .HasColumnName("amount");

            builder.Property(x => x.PaymentDate)
                .HasColumnName("payment_date");

            builder.Property(x => x.InvoiceType)
                .HasConversion<byte>()
                .HasColumnName("invoice_type");

            builder.Property(x => x.ReferenceInvoiceId)
                .HasColumnName("reference_invoice_id");
        }
    }

}
