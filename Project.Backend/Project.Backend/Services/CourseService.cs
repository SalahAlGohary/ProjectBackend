using AutoMapper;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Services;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository,
            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<CourseDTO> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course != null)
            {
                var courseDto = _mapper.Map<CourseDTO>(course);
                return courseDto;
            }
            return null;
        }
        public async Task<List<CourseDTO>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            if (courses.Any())
            {
                var courseDtos = _mapper.Map<List<CourseDTO>>(courses);
                return courseDtos;
            }
            return null;
        }

    }
}
