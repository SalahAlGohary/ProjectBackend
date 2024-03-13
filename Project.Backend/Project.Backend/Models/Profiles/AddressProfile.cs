using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos.Address;

namespace Project.Backend.Models.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, GetAddressDto>();
            CreateMap<CreateAddressDto, Address>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateAddressDto, Address>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
