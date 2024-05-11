using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public class RecommendationRepository : GenericRepository<Recommendation>, IRecommendationRepository
    {
        ProjectDBContext _context;
        public RecommendationRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
