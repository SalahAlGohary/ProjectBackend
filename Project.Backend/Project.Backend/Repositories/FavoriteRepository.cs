using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        ProjectDBContext _context;
        public FavoriteRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
