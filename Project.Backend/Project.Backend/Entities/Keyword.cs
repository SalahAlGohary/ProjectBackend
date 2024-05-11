using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Keyword : BaseEntityNameCover
    {
        public virtual List<FoodRecipeKeyword> FoodRecipeKeywords { get; set; }

    }
}
