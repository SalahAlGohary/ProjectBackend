using AutoMapper;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Services;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IMapper _mapper;
        public FavoriteService(IFavoriteRepository favoriteRepository,
            IMapper mapper)
        {
            _favoriteRepository = favoriteRepository;
            _mapper = mapper;
        }
        public async Task<int> AddToFavorite(int RecipeId, Guid userId)
        {
            var result = await _favoriteRepository.AddToFavorite(RecipeId, userId);
            if (result != null)
            {
                return result;
            }
            return 0;
        }

        public async Task<List<FavoriteDTO>> GetAllFavorites(Guid userId)
        {
            var favorites = await _favoriteRepository.GetAllFavorites(userId);
            if (favorites.Any())
            {
                var favoritesDto = _mapper.Map<List<FavoriteDTO>>(favorites);
                return favoritesDto;
            }
            return null;
        }

        public async Task<bool> RemoveFromFavorite(int RecipeId, Guid userId)
        {
            var result = await _favoriteRepository.RemoveFromFavorite(RecipeId, userId);
            return result;
        }
    }
}
