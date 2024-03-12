using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Dish");
            builder
               .HasOne(c => c.Resturant)
               .WithMany(c => c.Dishes)
               .HasForeignKey(c => c.ResturantId);
        }
    }
}
