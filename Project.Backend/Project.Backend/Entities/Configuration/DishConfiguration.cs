using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<FoodRecipe>
    {
        public void Configure(EntityTypeBuilder<FoodRecipe> builder)
        {
            builder.ToTable("Recipe");
        }
    }
}
