using Project.Backend.Models.Dtos;

namespace Project.Backend.Contracts.Services
{
    public interface ICuisineService
    {
        Task<CuisineDTO> GetByIdAsync(int id);
        Task<List<CuisineDTO>> GetAllAsync();
    }
}
