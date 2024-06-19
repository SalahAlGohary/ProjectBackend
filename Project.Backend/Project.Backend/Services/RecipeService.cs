using AutoMapper;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Identity;
using Project.Backend.Contracts.Services;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public RecipeService(IRecipeRepository recipeRepository,
            IMapper mapper,
            IUserService userService)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<List<RecipeDTO>> GetAllAsync(int page = 1, int size = 10)
        {
            var recipeDtoList = new List<RecipeDTO>();
            var recipeList = await _recipeRepository.GetAllAsync(page, size);
            if (recipeList.Any())
            {
                var userIdString = _userService.UserId;
                if (userIdString != null)
                {
                    var userId = new Guid(userIdString);
                    foreach (var item in recipeList)
                    {
                        var recipeDto = _mapper.Map<RecipeDTO>(item);
                        recipeDto.IsFavorite = IsFavorite(userId, item);
                        recipeDtoList.Add(recipeDto);
                    }
                    return recipeDtoList;
                }
                recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByCollectionAsync(int collectionId, int page = 1, int size = 10)
        {
            var recipeDtoList = new List<RecipeDTO>();
            var recipeList = await _recipeRepository.GetAllByCollectionAsync(collectionId, page, size);
            if (recipeList.Any())
            {
                var userIdString = _userService.UserId;
                if (userIdString != null)
                {
                    var userId = new Guid(userIdString);
                    foreach (var item in recipeList)
                    {
                        var recipeDto = _mapper.Map<RecipeDTO>(item);
                        recipeDto.IsFavorite = IsFavorite(userId, item);
                        recipeDtoList.Add(recipeDto);
                    }
                    return recipeDtoList;
                }
                recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByCourseAsync(int courseId, int page = 1, int size = 10)
        {
            var recipeDtoList = new List<RecipeDTO>();
            var recipeList = await _recipeRepository.GetAllByCourseAsync(courseId, page, size);
            if (recipeList.Any())
            {
                var userIdString = _userService.UserId;
                if (userIdString != null)
                {
                    var userId = new Guid(userIdString);
                    foreach (var item in recipeList)
                    {
                        var recipeDto = _mapper.Map<RecipeDTO>(item);
                        recipeDto.IsFavorite = IsFavorite(userId, item);
                        recipeDtoList.Add(recipeDto);
                    }
                    return recipeDtoList;

                }
                recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByCuisineAsync(int cuisineId, int page = 1, int size = 10)
        {
            var recipeDtoList = new List<RecipeDTO>();
            var recipeList = await _recipeRepository.GetAllByCuisineAsync(cuisineId, page, size);
            if (recipeList.Any())
            {
                var userIdString = _userService.UserId;
                if (userIdString != null)
                {
                    var userId = new Guid(userIdString);
                    foreach (var item in recipeList)
                    {
                        var recipeDto = _mapper.Map<RecipeDTO>(item);
                        recipeDto.IsFavorite = IsFavorite(userId, item);
                        recipeDtoList.Add(recipeDto);
                    }
                    return recipeDtoList;

                }
                recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByDietTypeAsync(int dietTypeId, int page = 1, int size = 10)
        {
            var recipeDtoList = new List<RecipeDTO>();
            var recipeList = await _recipeRepository.GetAllByDietTypeAsync(dietTypeId, page, size);
            if (recipeList.Any())
            {
                var userIdString = _userService.UserId;
                if (userIdString != null)
                {
                    var userId = new Guid(userIdString);
                    foreach (var item in recipeList)
                    {
                        var recipeDto = _mapper.Map<RecipeDTO>(item);
                        recipeDto.IsFavorite = IsFavorite(userId, item);
                        recipeDtoList.Add(recipeDto);
                    }
                    return recipeDtoList;

                }
                recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;

        }

        public async Task<IEnumerable<RecipeDTO>> GetAllByKeywordAsync(int keywordId, int page = 1, int size = 10)
        {
            var recipeDtoList = new List<RecipeDTO>();
            var recipeList = await _recipeRepository.GetAllByKeywordAsync(keywordId, page, size);
            if (recipeList.Any())
            {
                var userIdString = _userService.UserId;
                if (userIdString != null)
                {
                    var userId = new Guid(userIdString);
                    foreach (var item in recipeList)
                    {
                        var recipeDto = _mapper.Map<RecipeDTO>(item);
                        recipeDto.IsFavorite = IsFavorite(userId, item);
                        recipeDtoList.Add(recipeDto);
                    }
                    return recipeDtoList;

                }
                recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public async Task<RecipeDTO> GetByIdAsync(int id)
        {
            RecipeDTO recipeDto = null;
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe != null)
            {
                var userIdString = _userService.UserId;
                if (userIdString != null)
                {
                    var userId = new Guid(userIdString);
                    recipeDto = _mapper.Map<RecipeDTO>(recipe);
                    recipeDto.IsFavorite = IsFavorite(userId, recipe);
                    return recipeDto;
                }
                recipeDto = _mapper.Map<RecipeDTO>(recipe);
                return recipeDto;
            }
            return recipeDto;
        }

        public async Task<List<RecipeDTO>> GetByNameAsync(string name, int page = 1, int size = 10)
        {
            var recipeDtoList = new List<RecipeDTO>();
            var recipeList = await _recipeRepository.GetByNameAsync(name, page, size);
            if (recipeList.Any())
            {
                var userIdString = _userService.UserId;
                if (userIdString != null)
                {
                    var userId = new Guid(userIdString);
                    foreach (var item in recipeList)
                    {
                        var recipeDto = _mapper.Map<RecipeDTO>(item);
                        recipeDto.IsFavorite = IsFavorite(userId, item);
                        recipeDtoList.Add(recipeDto);
                    }
                    return recipeDtoList;

                }
                recipeDtoList = _mapper.Map<List<RecipeDTO>>(recipeList);
                return recipeDtoList;
            }
            return null;
        }

        public bool IsFavorite(Guid userId, FoodRecipe recipe)
        {
            var result = recipe.Favorites.FirstOrDefault(x => x.UserId == userId);
            if (result == null)
                return false;
            else
                return true;

        }
    }
}
