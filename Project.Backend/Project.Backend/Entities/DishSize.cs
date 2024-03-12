using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class DishSize : BaseEntityName
    {
        public decimal Price { get; set; }
        public Guid DishId { get; set; }
        public virtual Dish Dish { get; set; }

    }
}
