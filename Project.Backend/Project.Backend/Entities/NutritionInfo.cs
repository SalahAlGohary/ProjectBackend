using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class NutritionInfo : BaseEntityName
    {
        public virtual List<FoodRecipeNutritionInfo> FoodRecipeNutritionInfos { get; set; }

    }
}

