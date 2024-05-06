using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Dish : BaseEntityNameCover
    {
        public decimal? Description { get; set; }
        public decimal Calories { get; set; }
        public decimal Rate { get; set; }
        public int NumberOfLikes { get; set; }
        public virtual List<Favorite>? Favorites { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Cuisine> Cuisines { get; set; }
        public virtual List<Diet> Diets { get; set; }
        public virtual List<Recommendation> Recommendations { get; set; }
    }

}
