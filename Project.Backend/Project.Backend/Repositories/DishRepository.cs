using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class DishRepository : GenericRepository<Dish>
    {
        ProjectDBContext _context;
        public DishRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
