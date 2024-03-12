using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class DishSizeConfiguration : IEntityTypeConfiguration<DishSize>
    {
        public void Configure(EntityTypeBuilder<DishSize> builder)
        {
            builder.ToTable("DishSize");
            builder
               .HasOne(c => c.Dish)
               .WithMany(c => c.DishSizes)
               .HasForeignKey(c => c.DishId);

        }
    }
}
