using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Collection : BaseEntityNameCover
    {
        // List of Recipees
        public virtual List<FoodRecipeCollection> FoodRecipeCollections { get; set; }

    }
}
