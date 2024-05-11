using Microsoft.EntityFrameworkCore;
using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public class RecipeRepository : GenericRepository<FoodRecipe>, IRecipeRepository
    {
        ProjectDBContext _context;
        public RecipeRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }
        public virtual async Task<IEnumerable<FoodRecipe>> GetAllAsync(int page = 1, int size = 10)
        {
            return await _context.Set<FoodRecipe>()
                .Include(x => x.FoodRecipeIngredients)
                .ThenInclude(x => x.Ingredient)
                 .Include(x => x.FoodRecipeCollections)
                .ThenInclude(x => x.Collection)
                 .Include(x => x.FoodRecipeCourses)
                .ThenInclude(x => x.Course)
                 .Include(x => x.FoodRecipeNutritionInfos)
                .ThenInclude(x => x.NutritionInfo)
                 .Include(x => x.FoodRecipeKeywords)
                .ThenInclude(x => x.Keyword)
                .Include(x => x.Cuisine)
                .AsNoTracking().Where(q => !q.IsDeleted).Skip((page * size) - size).Take(size).ToListAsync();

        }
        public virtual async Task<IEnumerable<FoodRecipe>> GetAllByCuisineAsync(int cuisineId, int page = 1, int size = 10)
        {
            return await _context.Set<FoodRecipe>()
                .Include(x => x.FoodRecipeIngredients)
                .ThenInclude(x => x.Ingredient)
                 .Include(x => x.FoodRecipeCollections)
                .ThenInclude(x => x.Collection)
                 .Include(x => x.FoodRecipeCourses)
                .ThenInclude(x => x.Course)
                 .Include(x => x.FoodRecipeNutritionInfos)
                .ThenInclude(x => x.NutritionInfo)
                 .Include(x => x.FoodRecipeKeywords)
                .ThenInclude(x => x.Keyword)
                .Include(x => x.Cuisine)
                .AsNoTracking().Where(q => !q.IsDeleted && q.CuisineId == cuisineId).Skip((page * size) - size).Take(size).ToListAsync();

        }
        public virtual async Task<IEnumerable<FoodRecipe>> GetAllByKeywordAsync(int keywordId, int page = 1, int size = 10)
        {
            var RecipeIds = await _context.Set<FoodRecipeKeyword>()
                .AsNoTracking().Where(q => q.KeywordId == keywordId).Select(x => x.RecipeId).ToListAsync();
            var result = await _context.Set<FoodRecipe>()
                .Include(x => x.FoodRecipeIngredients)
                .ThenInclude(x => x.Ingredient)
                 .Include(x => x.FoodRecipeCollections)
                .ThenInclude(x => x.Collection)
                 .Include(x => x.FoodRecipeCourses)
                .ThenInclude(x => x.Course)
                 .Include(x => x.FoodRecipeNutritionInfos)
                .ThenInclude(x => x.NutritionInfo)
                 .Include(x => x.FoodRecipeKeywords)
                .ThenInclude(x => x.Keyword)
                .Include(x => x.Cuisine)
                .AsNoTracking().Where(q => !q.IsDeleted && RecipeIds.Contains(q.Id)).Skip((page * size) - size).Take(size).ToListAsync();
            return result;
        }
        public virtual async Task<IEnumerable<FoodRecipe>> GetAllByCollectionAsync(int collectionId, int page = 1, int size = 10)
        {
            var RecipeIds = await _context.Set<FoodRecipeCollection>()
                .AsNoTracking().Where(q => q.CollectionId == collectionId).Select(x => x.RecipeId).ToListAsync();
            var result = await _context.Set<FoodRecipe>()
                .Include(x => x.FoodRecipeIngredients)
                .ThenInclude(x => x.Ingredient)
                 .Include(x => x.FoodRecipeCollections)
                .ThenInclude(x => x.Collection)
                 .Include(x => x.FoodRecipeCourses)
                .ThenInclude(x => x.Course)
                 .Include(x => x.FoodRecipeNutritionInfos)
                .ThenInclude(x => x.NutritionInfo)
                 .Include(x => x.FoodRecipeKeywords)
                .ThenInclude(x => x.Keyword)
                .Include(x => x.Cuisine)
                .AsNoTracking().Where(q => !q.IsDeleted && RecipeIds.Contains(q.Id)).Skip((page * size) - size).Take(size).ToListAsync();
            return result;
        }
        public virtual async Task<IEnumerable<FoodRecipe>> GetAllByCourseAsync(int courseId, int page = 1, int size = 10)
        {
            var RecipeIds = await _context.Set<FoodRecipeCourse>()
                .AsNoTracking().Where(q => q.CourseId == courseId).Select(x => x.RecipeId).ToListAsync();
            var result = await _context.Set<FoodRecipe>()
                .Include(x => x.FoodRecipeIngredients)
                .ThenInclude(x => x.Ingredient)
                 .Include(x => x.FoodRecipeCollections)
                .ThenInclude(x => x.Collection)
                 .Include(x => x.FoodRecipeCourses)
                .ThenInclude(x => x.Course)
                 .Include(x => x.FoodRecipeNutritionInfos)
                .ThenInclude(x => x.NutritionInfo)
                 .Include(x => x.FoodRecipeKeywords)
                .ThenInclude(x => x.Keyword)
                .Include(x => x.Cuisine)
            .AsNoTracking().Where(q => !q.IsDeleted && RecipeIds.Contains(q.Id)).Skip((page * size) - size).Take(size).ToListAsync();
            return result;
        }
        public virtual async Task<IEnumerable<FoodRecipe>> GetAllByDietTypeAsync(int dietTypeId, int page = 1, int size = 10)
        {
            var RecipeIds = await _context.Set<FoodRecipeDietType>()
                .AsNoTracking().Where(q => q.DietTypeId == dietTypeId).Select(x => x.RecipeId).ToListAsync();
            var result = await _context.Set<FoodRecipe>()
                .Include(x => x.FoodRecipeIngredients)
                .ThenInclude(x => x.Ingredient)
                 .Include(x => x.FoodRecipeCollections)
                .ThenInclude(x => x.Collection)
                 .Include(x => x.FoodRecipeCourses)
                .ThenInclude(x => x.Course)
                 .Include(x => x.FoodRecipeNutritionInfos)
                .ThenInclude(x => x.NutritionInfo)
                 .Include(x => x.FoodRecipeKeywords)
                .ThenInclude(x => x.Keyword)
                .Include(x => x.Cuisine)
                .AsNoTracking().Where(q => !q.IsDeleted && RecipeIds.Contains(q.Id)).Skip((page * size) - size).Take(size).ToListAsync();
            return result;
        }

        public virtual async Task<FoodRecipe> GetByIdAsync(int id)
        {
            return await _context.Set<FoodRecipe>()
                .Include(x => x.FoodRecipeIngredients)
                .ThenInclude(x => x.Ingredient)
                 .Include(x => x.FoodRecipeCollections)
                .ThenInclude(x => x.Collection)
                 .Include(x => x.FoodRecipeCourses)
                .ThenInclude(x => x.Course)
                 .Include(x => x.FoodRecipeNutritionInfos)
                .ThenInclude(x => x.NutritionInfo)
                 .Include(x => x.FoodRecipeKeywords)
                .ThenInclude(x => x.Keyword)
                .Include(x => x.Cuisine)
               .AsNoTracking()
               .FirstOrDefaultAsync(q => q.Id == id && !q.IsDeleted);

        }
    }
}
