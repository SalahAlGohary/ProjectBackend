using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder
               .HasOne(c => c.Cart)
               .WithMany(c => c.Items)
               .HasForeignKey(c => c.CartId);
            builder
               .HasOne(c => c.Order)
               .WithMany(c => c.Items)
               .HasForeignKey(c => c.OrderId);
            builder
              .HasOne(c => c.Dish)
              .WithMany(c => c.Items)
              .HasForeignKey(c => c.DishId);
            builder
              .HasOne(c => c.DishSize)
              .WithMany(c => c.Items)
              .HasForeignKey(c => c.DishSizeId);

        }
    }
}
