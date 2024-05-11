using AutoMapper;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Services;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Services
{
    public class CuisineService : ICuisineService
    {
        private readonly ICuisineRepository _CuisineRepository;
        private readonly IMapper _mapper;
        public CuisineService(ICuisineRepository CuisineRepository,
            IMapper mapper)
        {
            _CuisineRepository = CuisineRepository;
            _mapper = mapper;
        }
        public async Task<CuisineDTO> GetByIdAsync(int id)
        {
            var Cuisine = await _CuisineRepository.GetByIdAsync(id);
            if (Cuisine != null)
            {
                var CuisineDto = _mapper.Map<CuisineDTO>(Cuisine);
                return CuisineDto;
            }
            return null;
        }
        public async Task<List<CuisineDTO>> GetAllAsync()
        {
            var Cuisines = await _CuisineRepository.GetAllAsync();
            if (Cuisines.Any())
            {
                var CuisineDtos = _mapper.Map<List<CuisineDTO>>(Cuisines);
                return CuisineDtos;
            }
            return null;
        }
    }
}
