namespace Project.Backend.Entities
{
    public class FoodRecipeCourse
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int RecipeId { get; set; }
        public FoodRecipe Recipe { get; set; }
    }
}


