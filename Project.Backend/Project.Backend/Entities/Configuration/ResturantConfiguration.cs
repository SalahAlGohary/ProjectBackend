using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class ResturantConfiguration : IEntityTypeConfiguration<Resturant>
    {
        public void Configure(EntityTypeBuilder<Resturant> builder)
        {
            builder.ToTable("Restuarant");
            builder
               .HasOne(c => c.Address)
               .WithMany(c => c.Restuarants)
               .HasForeignKey(c => c.AddressId);

        }

    }
}
