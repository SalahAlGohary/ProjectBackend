using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder
               .HasOne(c => c.Restuarant)
               .WithMany(c => c.Carts)
               .HasForeignKey(c => c.RestuarantId);
        }
    }
}
