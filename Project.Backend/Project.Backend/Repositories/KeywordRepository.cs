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

    }
}
