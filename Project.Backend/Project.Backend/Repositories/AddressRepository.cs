using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class AddressRepository : GenericRepository<Address>
    {
        ProjectDBContext _context;
        public AddressRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
