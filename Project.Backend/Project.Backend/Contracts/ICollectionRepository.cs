using Project.Backend.Entities;

namespace Project.Backend.Contracts
{
    public interface ICollectionRepository : IGenericRepository<Collection>
    {
        Task<IEnumerable<Collection>> GetAllAsync(int page = 1, int size = 10);
    }
}
