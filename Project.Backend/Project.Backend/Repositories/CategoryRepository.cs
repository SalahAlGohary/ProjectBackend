using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        ProjectDBContext _context;
        public CategoryRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
