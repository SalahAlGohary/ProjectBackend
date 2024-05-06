using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class FavoriteRepository : GenericRepository<Favorite>
    {
        ProjectDBContext _context;
        public FavoriteRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
