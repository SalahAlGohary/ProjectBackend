using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Cuisine : BaseEntityNameCover
    {
        // List of Recipees
        public virtual List<FoodRecipe>? Recipes { get; set; }

    }
}
