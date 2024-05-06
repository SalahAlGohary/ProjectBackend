using Project.Backend.Contracts;
using Project.Backend.Contracts.Services;

namespace Project.Backend.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
    }
}
