namespace Project.Backend.Entities
{
    public class FoodRecipeNutritionInfo
    {
        public int NutritionInfoId { get; set; }
        public NutritionInfo NutritionInfo { get; set; }
        public int RecipeId { get; set; }
        public FoodRecipe Recipe { get; set; }
    }
}


