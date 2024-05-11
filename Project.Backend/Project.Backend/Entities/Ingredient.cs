using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Ingredient : BaseEntityName
    {
        public virtual List<FoodRecipeIngredient> FoodRecipeIngredients { get; set; }

    }
}


