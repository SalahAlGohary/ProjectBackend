using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Category : BaseEntityNameCover
    {
        // List of Dishes
        public virtual List<Dish>? Dishes { get; set; }

    }
}
