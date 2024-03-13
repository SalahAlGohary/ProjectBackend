namespace Project.Backend.Models.Dtos.Dish
{
    public class CreateDishDto
    {
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public decimal? Description { get; set; }
        public string? CoverUrl { get; set; }
        public virtual List<CreateDishSizeDto>? DishSizes { get; set; }
    }
}
