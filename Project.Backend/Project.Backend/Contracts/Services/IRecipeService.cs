using Project.Backend.Models.Dtos;

namespace Project.Backend.Contracts.Services
{
    public interface IRecipeService
    {
        Task<RecipeDTO> GetByIdAsync(int id);
        Task<List<RecipeDTO>> GetAllAsync(int page = 1, int size = 10);
        Task<IEnumerable<RecipeDTO>> GetAllByCuisineAsync(int cuisineId, int page = 1, int size = 10);
        Task<IEnumerable<RecipeDTO>> GetAllByKeywordAsync(int keywordId, int page = 1, int size = 10);
        Task<IEnumerable<RecipeDTO>> GetAllByCollectionAsync(int collectionId, int page = 1, int size = 10);
        Task<IEnumerable<RecipeDTO>> GetAllByCourseAsync(int courseId, int page = 1, int size = 10);
        Task<IEnumerable<RecipeDTO>> GetAllByDietTypeAsync(int dietTypeId, int page = 1, int size = 10);
    }
}
