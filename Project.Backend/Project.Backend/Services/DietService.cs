using AutoMapper;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Services;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Services
{
    public class DietService : IDietService
    {
        private readonly IDietRepository _DietRepository;
        private readonly IMapper _mapper;
        public DietService(IDietRepository DietRepository,
            IMapper mapper)
        {
            _DietRepository = DietRepository;
            _mapper = mapper;
        }
        public async Task<DietTypeDTO> GetByIdAsync(int id)
        {
            var DietType = await _DietRepository.GetByIdAsync(id);
            if (DietType != null)
            {
                var DietTypeDto = _mapper.Map<DietTypeDTO>(DietType);
                return DietTypeDto;
            }
            return null;
        }
        public async Task<List<DietTypeDTO>> GetAllAsync()
        {
            var DietTypes = await _DietRepository.GetAllAsync();
            if (DietTypes.Any())
            {
                var DietTypeDtos = _mapper.Map<List<DietTypeDTO>>(DietTypes);
                return DietTypeDtos;
            }
            return null;
        }
    }
}
