namespace Project.Backend.Entities
{
    public class FoodRecipeKeyword
    {
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
        public int RecipeId { get; set; }
        public FoodRecipe Recipe { get; set; }
    }
}


