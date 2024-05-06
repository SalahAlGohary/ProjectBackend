using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        ProjectDBContext _context;
        public AddressRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
