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
    public class RoutingStepConfiguration : IEntityTypeConfiguration<RoutingStep>
    {
        public void Configure(EntityTypeBuilder<RoutingStep> builder)
        {
            builder.ToTable("routing_steps");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.RoutingId).HasColumnName("routing_id");
            builder.Property(x => x.StepOrder).HasColumnName("step_order");

            builder.Property(x => x.OperationName)
                .HasMaxLength(255)
                .HasColumnName("operation_name");

            builder.Property(x => x.OperationTime)
                .HasColumnName("operation_time");

            builder.Property(x => x.Images)
                .HasColumnType("text[]")
                .HasColumnName("images");

            builder.Property(x => x.Note).HasColumnName("note");

            builder.HasOne(x => x.Routing)
                .WithMany()
                .HasForeignKey(x => x.RoutingId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_routingstep_routing");
        }
    }
}
