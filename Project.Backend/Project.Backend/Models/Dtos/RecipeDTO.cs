namespace Project.Backend.Models.Dtos
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CoverUrl { get; set; }
        public string? Description { get; set; }
        public decimal Calories { get; set; }
        public int NumberOfLikes { get; set; }
        public int CookingTime { get; set; }
        public int PrepTime { get; set; }
        public int Serves { get; set; }
        public int Ratings { get; set; }
        public string? SkillLevel { get; set; }
        public string? PostDates { get; set; }
        public List<string>? NutritionInfos { get; set; }
        public List<string>? Ingredients { get; set; }
        public List<string>? Keywords { get; set; }
        public bool? IsFavorite { get; set; } = false;

    }
}
