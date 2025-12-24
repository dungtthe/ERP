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
    public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
    {
        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            builder.ToTable("work_orders");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.HasIndex(x => new { x.ManufacturingOrderId, x.WorkCenterId, x.RoutingStepId });

            builder.Property(x => x.ManufacturingOrderId).HasColumnName("mo_id");
            builder.Property(x => x.WorkCenterId).HasColumnName("work_center_id");
            builder.Property(x => x.RoutingStepId).HasColumnName("routing_step_id");

            builder.HasOne(x => x.ManufacturingOrder)
                .WithMany()
                .HasForeignKey(x => x.ManufacturingOrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_wo_mo");

            builder.HasOne(x => x.WorkCenter)
                .WithMany()
                .HasForeignKey(x => x.WorkCenterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_wo_workcenter");

            builder.HasOne(x => x.RoutingStep)
                .WithMany()
                .HasForeignKey(x => x.RoutingStepId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_wo_routingstep");
        }
    }
}
