namespace Project.Backend.Entities
{
    public class FoodRecipeIngredient
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int RecipeId { get; set; }
        public FoodRecipe Recipe { get; set; }
    }
}


