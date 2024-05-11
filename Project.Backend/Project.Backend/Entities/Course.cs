using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Course : BaseEntityNameCover
    {
        // List of Recipees
        public virtual List<FoodRecipeCourse> FoodRecipeCourses { get; set; }
    }
}
