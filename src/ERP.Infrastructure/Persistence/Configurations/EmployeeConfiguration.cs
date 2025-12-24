using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");

            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("first_name");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("last_name");

            builder.Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("position");

            builder.Property(e => e.HireDate)
                .IsRequired()
                .HasColumnName("hire_date");

            builder.Property(e => e.DateOfBirth)
                .HasColumnName("date_of_birth");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("status");

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("gender");

            builder.Property(e => e.Salary)
                .IsRequired()
                .HasColumnType("numeric(18,4)")
                .HasColumnName("salary");

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("user_id");

            builder.HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired()
                .HasConstraintName("FK_Employees_Users");

            builder.Property(x => x.DepartmentId)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("department_id");

            builder.HasOne(e => e.Department)
              .WithMany(x => x.Employees)
              .HasForeignKey(e => e.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict)
              .HasConstraintName("FK_Employees_Departments");

        }
    }
}