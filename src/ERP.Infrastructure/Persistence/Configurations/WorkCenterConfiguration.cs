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
    public class WorkCenterConfiguration : IEntityTypeConfiguration<WorkCenter>
    {
        public void Configure(EntityTypeBuilder<WorkCenter> builder)
        {
            builder.ToTable("work_centers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");

            builder.Property(x => x.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");

            builder.Property(x => x.CostPerHour)
                .HasColumnType("numeric(18,4)")
                .HasColumnName("cost_per_hour");
        }
    }
}
