using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class CourseRepository : GenericRepository<Course>
    {
        ProjectDBContext _context;
        public CourseRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
