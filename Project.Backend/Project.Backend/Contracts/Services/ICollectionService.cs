using Project.Backend.Models.Dtos;

namespace Project.Backend.Contracts.Services
{
    public interface ICollectionService
    {
        Task<CollectionDTO> GetByIdAsync(int id);
        Task<List<CollectionDTO>> GetAllAsync(int page = 0, int size = 0);
    }
}
