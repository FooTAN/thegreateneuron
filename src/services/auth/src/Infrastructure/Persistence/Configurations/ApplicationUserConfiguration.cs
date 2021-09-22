using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable<ApplicationUser>("Users");
            builder.HasKey("Id");
            builder.Property(au => au.Id)
                .HasColumnType("char")
                .HasColumnName("Id")
                .HasMaxLength(38)
                .IsRequired();
            builder.Property(au => au.UserName)
                .HasColumnName("UserName")
                .HasColumnType("varchar")
                .HasMaxLength(99)
                .IsRequired();
            builder.Property(au => au.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("BLOB");
            builder.Property(au => au.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .HasColumnType("BLOB");
            builder.Property(au => au.Roles)
                .HasColumnName("Roles")
                .HasColumnType("varchar");
        }
    }
}
