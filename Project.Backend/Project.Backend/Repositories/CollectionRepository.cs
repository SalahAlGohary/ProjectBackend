using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Collection>> GetAllAsync(int page = 1, int size = 10)
        {
            return await _context.Set<Collection>().AsNoTracking().Skip((page * size) - size).Take(size).ToListAsync();
        }

    }
}
