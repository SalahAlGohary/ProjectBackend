using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class CuisineRepository : GenericRepository<Cuisine>, ICuisineRepository
    {
        ProjectDBContext _context;
        public CuisineRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
