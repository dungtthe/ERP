using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ERP.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("phone_number");

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("address");

            builder.Property(x => x.AvatarUrl)
                .HasColumnName("avatar_url");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Password)
                .HasMaxLength(100)
                .HasColumnName("password");

            builder.Property(x => x.IsLock)
                .IsRequired()
                .HasColumnName("is_lock");
        }
    }
}
