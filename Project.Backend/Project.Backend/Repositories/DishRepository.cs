using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        ProjectDBContext _context;
        public DishRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
