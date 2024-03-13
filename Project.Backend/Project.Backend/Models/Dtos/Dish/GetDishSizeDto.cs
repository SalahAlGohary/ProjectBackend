namespace Project.Backend.Models.Dtos.Dish
{
    public class GetDishSizeDto
    {
        public Guid Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public decimal Price { get; set; }
    }
}
