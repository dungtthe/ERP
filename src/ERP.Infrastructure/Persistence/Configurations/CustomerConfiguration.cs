using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("company_name");

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("user_id");

            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Customer>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired()
                .HasConstraintName("FK_Customers_Users");

            builder.HasIndex(x => x.UserId)
            .IsUnique();



        }
    }
}