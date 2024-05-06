using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class DietRepository : GenericRepository<Diet>, IDietRepository
    {
        ProjectDBContext _context;
        public DietRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
