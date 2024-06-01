using Microsoft.EntityFrameworkCore;
using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        ProjectDBContext _context;
        public FavoriteRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<int> AddToFavorite(int RecipeId, Guid userId)
        {
            var fav = new Favorite()
            {
                RecipeId = RecipeId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };
            await _context.Favorites.AddAsync(fav);
            return await _context.SaveChangesAsync();
        }
        public async Task<List<Favorite>> GetAllFavorites(Guid userId)
        {
            var favorites = await _context.Favorites
                 .Include(x => x.Recipe).Where(x => x.UserId == userId).ToListAsync();

            return favorites;
        }
        public async Task<bool> RemoveFromFavorite(int RecipeId, Guid userId)
        {
            var fav = await _context.Favorites.FirstOrDefaultAsync(x => x.RecipeId == RecipeId && x.UserId == userId && !x.IsDeleted);
            if (fav == null)
                return false;
            fav.IsDeleted = true;
            var x = _context.Update(fav);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
