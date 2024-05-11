using Project.Backend.Models.Dtos;

namespace Project.Backend.Contracts.Services
{
    public interface ICourseService
    {
        Task<CourseDTO> GetByIdAsync(int id);
        Task<List<CourseDTO>> GetAllAsync();

    }
}
