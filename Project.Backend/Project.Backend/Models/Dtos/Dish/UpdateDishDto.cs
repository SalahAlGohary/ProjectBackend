namespace Project.Backend.Models.Dtos.Dish
{
    public class UpdateDishDto
    {
        public Guid Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public decimal? Description { get; set; }
    }
}
