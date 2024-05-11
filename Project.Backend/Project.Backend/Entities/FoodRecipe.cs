using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class FoodRecipe : BaseEntityNameCover
    {
        public string? Description { get; set; }
        public decimal Calories { get; set; }
        public int NumberOfLikes { get; set; }
        public int CookingTime { get; set; }
        public int PrepTime { get; set; }
        public int Serves { get; set; }
        public int Ratings { get; set; }
        public int CuisineId { get; set; }
        public Cuisine? Cuisine { get; set; }
        public string? SkillLevel { get; set; }
        public string? PostDates { get; set; }
        public List<FoodRecipeNutritionInfo>? FoodRecipeNutritionInfos { get; set; }
        public List<FoodRecipeCourse>? FoodRecipeCourses { get; set; }
        public List<FoodRecipeIngredient>? FoodRecipeIngredients { get; set; }
        public List<FoodRecipeDietType>? FoodRecipeDietTypes { get; set; }
        public List<FoodRecipeKeyword>? FoodRecipeKeywords { get; set; }
        public List<FoodRecipeCollection>? FoodRecipeCollections { get; set; }
        public virtual List<Favorite>? Favorites { get; set; }
    }

}
