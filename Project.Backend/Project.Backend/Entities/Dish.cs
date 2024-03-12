using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Dish : BaseEntityName
    {
        public decimal? Description { get; set; }
        public string? CoverUrl { get; set; }
        public bool IsFavorite { get; set; }
        public Guid? ResturantId { get; set; }
        public virtual Resturant? Resturant { get; set; }
        public virtual List<DishSize>? DishSizes { get; set; }



    }
}
