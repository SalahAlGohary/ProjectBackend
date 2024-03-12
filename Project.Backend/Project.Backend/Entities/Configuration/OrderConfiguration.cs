using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder
               .HasOne(c => c.Restuarant)
               .WithMany(c => c.Orders)
               .HasForeignKey(c => c.ResturantId);
            builder
               .HasOne(c => c.Address)
               .WithMany(c => c.Orders)
               .HasForeignKey(c => c.AddressId);
            builder
               .HasOne(c => c.User)
               .WithMany(c => c.Orders)
               .HasForeignKey(c => c.UserId);
        }
    }
}
