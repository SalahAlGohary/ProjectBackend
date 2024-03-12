using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class UserAddressesConfiguration : IEntityTypeConfiguration<UserAddresses>
    {
        public void Configure(EntityTypeBuilder<UserAddresses> builder)
        {
            builder.ToTable("UserAddresses");
            builder
               .HasOne(c => c.Address)
               .WithMany(c => c.UserAddresses)
               .HasForeignKey(c => c.AddressId);
            builder
               .HasOne(c => c.User)
               .WithMany(c => c.UserAddresses)
               .HasForeignKey(c => c.UserId);
        }
    }
}
