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
    public class GoodsIssueConfiguration : IEntityTypeConfiguration<GoodsIssue>
    {
        public void Configure(EntityTypeBuilder<GoodsIssue> builder)
        {
            builder.ToTable("goods_issues");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("code");

            builder.Property(x => x.IssueDate)
                .HasColumnName("issue_date");

            builder.Property(x => x.IssueType)
                .HasConversion<byte>()
                .HasColumnName("issue_type");

            builder.Property(x => x.ReferenceId)
                .HasColumnName("reference_id");
        }
    }

}
