using AutoMapper;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Services;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Services
{
    public class KeywordService : IKeywordService
    {
        private readonly IKeywordRepository _KeywordRepository;
        private readonly IMapper _mapper;
        public KeywordService(IKeywordRepository KeywordRepository,
            IMapper mapper)
        {
            _KeywordRepository = KeywordRepository;
            _mapper = mapper;
        }
        public async Task<KeywordDTO> GetByIdAsync(int id)
        {
            var KeywordType = await _KeywordRepository.GetByIdAsync(id);
            if (KeywordType != null)
            {
                var KeywordTypeDto = _mapper.Map<KeywordDTO>(KeywordType);
                return KeywordTypeDto;
            }
            return null;
        }
        public async Task<List<KeywordDTO>> GetAllAsync(int page = 1, int size = 10)
        {
            var KeywordTypes = await _KeywordRepository.GetAllAsync(page, size);
            if (KeywordTypes.Any())
            {
                var KeywordTypeDtos = _mapper.Map<List<KeywordDTO>>(KeywordTypes);
                return KeywordTypeDtos;
            }
            return null;
        }
    }
}
