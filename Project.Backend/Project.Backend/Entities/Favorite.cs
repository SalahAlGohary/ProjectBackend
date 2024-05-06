using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Favorite : BaseEntity
    {
        public Guid DishId { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Dish Dish { get; set; }


    }
}
