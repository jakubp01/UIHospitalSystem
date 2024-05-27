using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inz.Areas.Identity.Data
{
    internal class AppUserEntityConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(9);
            builder.Property(u => u.HomeAddress).IsRequired().HasMaxLength(255);
            builder.Property(u => u.IdentityNumber).IsRequired().HasMaxLength(11);
        }
    }
}