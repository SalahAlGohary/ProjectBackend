using Project.Backend.Entities;

namespace Project.Backend.Contracts
{
    public interface IRecipeRepository : IGenericRepository<FoodRecipe>
    {
        Task<IEnumerable<FoodRecipe>> GetAllAsync(int page = 1, int size = 10);
        Task<IEnumerable<FoodRecipe>> GetByNameAsync(string name, int page = 1, int size = 10);
        Task<IEnumerable<FoodRecipe>> GetAllByCuisineAsync(int cuisineId, int page = 1, int size = 10);
        Task<IEnumerable<FoodRecipe>> GetAllByKeywordAsync(int keywordId, int page = 1, int size = 10);
        Task<IEnumerable<FoodRecipe>> GetAllByCollectionAsync(int collectionId, int page = 1, int size = 10);
        Task<IEnumerable<FoodRecipe>> GetAllByCourseAsync(int courseId, int page = 1, int size = 10);
        Task<IEnumerable<FoodRecipe>> GetAllByDietTypeAsync(int dietTypeId, int page = 1, int size = 10);
    }
}
