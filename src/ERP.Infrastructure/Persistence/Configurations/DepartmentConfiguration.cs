using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(d => d.Positions)
                    .HasColumnName("positions")
                    .HasColumnType("text[]");

            builder.Property(x => x.EmployeeId)
                .HasMaxLength(200)
                .HasColumnName("employee_id");

            builder.HasOne(x => x.Employee)
                .WithOne()
                .HasForeignKey<Department>(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Departments_Employees");
        }
    }
}