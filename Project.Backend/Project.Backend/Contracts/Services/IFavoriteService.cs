using Project.Backend.Models.Dtos;

namespace Project.Backend.Contracts.Services
{
    public interface IFavoriteService
    {
        Task<int> AddToFavorite(int RecipeId, Guid userId);
        Task<List<FavoriteDTO>> GetAllFavorites(Guid userId);
        Task<bool> RemoveFromFavorite(int RecipeId, Guid userId);
    }
}
