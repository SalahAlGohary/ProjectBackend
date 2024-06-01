using Project.Backend.Entities;

namespace Project.Backend.Contracts
{
    public interface IFavoriteRepository : IGenericRepository<Favorite>
    {
        Task<int> AddToFavorite(int RecipeId, Guid userId);
        Task<List<Favorite>> GetAllFavorites(Guid userId);
        Task<bool> RemoveFromFavorite(int RecipeId, Guid userId);

    }
}
