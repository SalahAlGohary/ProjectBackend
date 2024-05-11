using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public class DietTypeRepository : GenericRepository<DietType>, IDietRepository
    {
        ProjectDBContext _context;
        public DietTypeRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
