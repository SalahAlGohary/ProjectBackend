using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class DietType : BaseEntityNameCover
    {
        // List of Recipees
        public virtual List<FoodRecipeDietType> FoodRecipeDietTypes { get; set; }
    }
}
