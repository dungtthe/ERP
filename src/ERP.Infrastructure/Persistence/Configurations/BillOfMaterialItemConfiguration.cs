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
    public class BillOfMaterialItemConfiguration : IEntityTypeConfiguration<BillOfMaterialItem>
    {
        public void Configure(EntityTypeBuilder<BillOfMaterialItem> builder)
        {
            builder.ToTable("bill_of_material_items");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.BillOfMaterialId).HasColumnName("bom_id");
            builder.Property(x => x.MaterialId).HasColumnName("material_id");
            builder.Property(x => x.QuantityRequired).HasColumnName("quantity_required");
            builder.Property(x => x.UnitOfMeasureId).HasColumnName("uom_id");

            builder.HasOne(x => x.BillOfMaterial)
                .WithMany()
                .HasForeignKey(x => x.BillOfMaterialId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_bomi_bom");

            builder.HasOne(x => x.Material)
                .WithMany()
                .HasForeignKey(x => x.MaterialId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_bomi_material");

            builder.HasOne(x => x.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(x => x.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_bomi_uom");
        }
    }
}
