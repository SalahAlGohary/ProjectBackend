using Microsoft.EntityFrameworkCore;
using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public class KeywordRepository : GenericRepository<Keyword>, IKeywordRepository
    {
        ProjectDBContext _context;
        public KeywordRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Keyword>> GetAllAsync(int page = 1, int size = 10)
        {
            return await _context.Set<Keyword>().AsNoTracking().Skip((page * size) - size).Take(size).ToListAsync();
        }
    }
}
