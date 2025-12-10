using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("suppliers");

            builder.HasKey(x => x.Id);

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
               .HasForeignKey<Supplier>(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired()
               .HasConstraintName("FK_Suppliers_Users");

            builder.HasIndex(x => x.UserId)
                .IsUnique();
        }
    }
}