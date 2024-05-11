namespace Project.Backend.Models.Dtos.Recipe
{
    public class CreateRecipeDto
    {
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public decimal? Description { get; set; }
        public string? CoverUrl { get; set; }
    }
}
