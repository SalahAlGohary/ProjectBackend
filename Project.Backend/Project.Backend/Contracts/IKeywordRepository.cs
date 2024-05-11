using Project.Backend.Entities;

namespace Project.Backend.Contracts
{
    public interface IKeywordRepository : IGenericRepository<Keyword>
    {
        Task<List<Keyword>> GetAllAsync(int page = 1, int size = 10);
    }
}
