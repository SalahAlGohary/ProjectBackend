namespace Project.Backend.Entities
{
    public class FoodRecipeCollection
    {
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
        public int RecipeId { get; set; }
        public FoodRecipe Recipe { get; set; }
    }
}


