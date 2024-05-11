using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Recommendation : BaseEntity
    {
        // List of Recipees
        public virtual List<FoodRecipe>? Recipes { get; set; }

    }
}
