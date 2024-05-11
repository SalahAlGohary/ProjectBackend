using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
    {
        ProjectDBContext _context;
        public CollectionRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
