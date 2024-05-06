using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class CuisineRepository : GenericRepository<Cuisine>
    {
        ProjectDBContext _context;
        public CuisineRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
