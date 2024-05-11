namespace Project.Backend.Entities
{
    public class FoodRecipeDietType
    {
        public int DietTypeId { get; set; }
        public DietType DietType { get; set; }
        public int RecipeId { get; set; }
        public FoodRecipe Recipe { get; set; }
    }
}


