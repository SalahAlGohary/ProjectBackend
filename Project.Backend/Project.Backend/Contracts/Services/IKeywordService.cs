using Project.Backend.Models.Dtos;

namespace Project.Backend.Contracts.Services
{
    public interface IKeywordService
    {
        Task<KeywordDTO> GetByIdAsync(int id);
        Task<List<KeywordDTO>> GetAllAsync();
    }
}
