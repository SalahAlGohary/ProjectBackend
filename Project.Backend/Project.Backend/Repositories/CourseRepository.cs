using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        ProjectDBContext _context;
        public CourseRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
