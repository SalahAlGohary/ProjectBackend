using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public class RecipeRepository : GenericRepository<FoodRecipe>, IRecipeRepository
    {
        ProjectDBContext _context;
        public RecipeRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
