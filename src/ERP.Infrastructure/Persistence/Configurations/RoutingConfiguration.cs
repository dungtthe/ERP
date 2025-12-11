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
    public class RoutingConfiguration : IEntityTypeConfiguration<Routing>
    {
        public void Configure(EntityTypeBuilder<Routing> builder)
        {
            builder.ToTable("routings");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.BillOfMaterialId).HasColumnName("bom_id");
            builder.Property(x => x.Version).HasColumnName("version");
            builder.Property(x => x.Note).HasColumnName("note");

            builder.HasOne(x => x.BillOfMaterial)
                .WithMany()
                .HasForeignKey(x => x.BillOfMaterialId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_routing_bom");
        }
    }
}
