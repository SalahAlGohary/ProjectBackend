using AutoMapper;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Services;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionRepository _CollectionRepository;
        private readonly IMapper _mapper;
        public CollectionService(ICollectionRepository CollectionRepository,
            IMapper mapper)
        {
            _CollectionRepository = CollectionRepository;
            _mapper = mapper;
        }
        public async Task<CollectionDTO> GetByIdAsync(int id)
        {
            var Collection = await _CollectionRepository.GetByIdAsync(id);
            if (Collection != null)
            {
                var CollectionDto = _mapper.Map<CollectionDTO>(Collection);
                return CollectionDto;
            }
            return null;
        }
        public async Task<List<CollectionDTO>> GetAllAsync(int page = 1, int size = 10)
        {
            var Collections = await _CollectionRepository.GetAllAsync(page, size);
            if (Collections.Any())
            {
                var CollectionDtos = _mapper.Map<List<CollectionDTO>>(Collections);
                return CollectionDtos;
            }
            return null;
        }
    }
}
