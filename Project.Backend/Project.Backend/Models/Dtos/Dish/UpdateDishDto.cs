namespace Project.Backend.Models.Dtos.Recipe
{
    public class UpdateRecipeDto
    {
        public Guid Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public decimal? Description { get; set; }
    }
}
