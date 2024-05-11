using AutoMapper;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Services;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository,
            IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<List<RecipeDTO>> GetAllAsync(int page = 1, int size = 10)
        {
            var recipeList = await _recipeRepository.GetAllAsync(page, size);
            if (recipeList.Any())
            {
                var recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByCollectionAsync(int collectionId, int page = 1, int size = 10)
        {
            var recipeList = await _recipeRepository.GetAllByCollectionAsync(collectionId, page, size);
            if (recipeList.Any())
            {
                var recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByCourseAsync(int courseId, int page = 1, int size = 10)
        {
            var recipeList = await _recipeRepository.GetAllByCourseAsync(courseId, page, size);
            if (recipeList.Any())
            {
                var recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByCuisineAsync(int cuisineId, int page = 1, int size = 10)
        {
            var recipeList = await _recipeRepository.GetAllByCuisineAsync(cuisineId, page, size);
            if (recipeList.Any())
            {
                var recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByDietTypeAsync(int dietTypeId, int page = 1, int size = 10)
        {
            var recipeList = await _recipeRepository.GetAllByDietTypeAsync(dietTypeId, page, size);
            if (recipeList.Any())
            {
                var recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;

        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByKeywordAsync(int keywordId, int page = 1, int size = 10)
        {
            var recipeList = await _recipeRepository.GetAllByKeywordAsync(keywordId, page, size);
            if (recipeList.Any())
            {
                var recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<RecipeDTO> GetByIdAsync(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe != null)
            {
                var recipeDto = _mapper.Map<RecipeDTO>(recipe);
                return recipeDto;
            }
            return null;
        }
    }
}
