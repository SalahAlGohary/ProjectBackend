using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Course : BaseEntityNameCover
    {
        // List of Dishes
        public virtual List<Dish>? Dishes { get; set; }

    }
}
