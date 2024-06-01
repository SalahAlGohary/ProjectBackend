using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Favorite : BaseEntity
    {
        public int RecipeId { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual FoodRecipe Recipe { get; set; }


    }
}
