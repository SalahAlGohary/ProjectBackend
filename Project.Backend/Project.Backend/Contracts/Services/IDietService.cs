using Project.Backend.Models.Dtos;

namespace Project.Backend.Contracts.Services
{
    public interface IDietService
    {
        Task<DietTypeDTO> GetByIdAsync(int id);
        Task<List<DietTypeDTO>> GetAllAsync();
    }
}
