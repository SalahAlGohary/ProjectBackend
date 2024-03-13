namespace Project.Backend.Models.Dtos.Dish
{
    public class GetDishDto
    {
        public Guid Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public decimal? Description { get; set; }
        public string? CoverUrl { get; set; }
        public Guid? ResturantId { get; set; }
        public virtual List<GetDishSizeDto>? DishSizes { get; set; }
    }
}
