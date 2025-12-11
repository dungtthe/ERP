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
    public class ManufacturingOrderConfiguration : IEntityTypeConfiguration<ManufacturingOrder>
    {
        public void Configure(EntityTypeBuilder<ManufacturingOrder> builder)
        {
            builder.ToTable("manufacturing_orders");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("code");

            builder.Property(x => x.ProductVariantRoutingId)
                .HasColumnName("routing_id");

            builder.Property(x => x.QuantityToProduce).HasColumnName("qty_to_produce");
            builder.Property(x => x.QuantityProduced).HasColumnName("qty_produced");

            builder.Property(x => x.ManufacturingOrderStatus)
                .HasColumnName("status")
                .HasConversion<byte>();

            builder.Property(x => x.StartDate).HasColumnName("start_date");
            builder.Property(x => x.EndDate).HasColumnName("end_date");

            builder.HasOne(x => x.ProductVariantRouting)
                .WithMany()
                .HasForeignKey(x => x.ProductVariantRoutingId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_mo_routing");
        }
    }
}
