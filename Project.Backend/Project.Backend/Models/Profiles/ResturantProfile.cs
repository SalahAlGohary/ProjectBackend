using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos.Resturant;
using System.Text;

namespace Project.Backend.Models.Profiles
{
    public class ResturantProfile : Profile
    {
        public ResturantProfile()
        {
            CreateMap<Resturant, GetResturantDto>()
                 .ForMember(dest => dest.AddressDetail, opt => opt.MapFrom(src => CompineAddress(src.Address)));
            CreateMap<CreateResturantDto, Resturant>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateResturantDto, Resturant>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));
        }
        private string CompineAddress(Address address)
        {
            StringBuilder result = new StringBuilder();
            if (address != null)
            {
                if (address.City != null)
                {
                    result.Append(address.City);
                    result.Append(" - ");
                }
                if (address.Street != null)
                {
                    result.Append(address.Street);
                    result.Append(" - ");
                }
                if (address.Line1 != null)
                {
                    result.Append(address.Line1);
                    result.Append(" - ");
                }
                if (address.Line2 != null)
                {
                    result.Append(address.Line2);
                    result.Append(" - ");
                }
                if (address.Floor != null)
                {
                    result.Append(address.Floor);
                    result.Append(" - ");
                }
                if (address.Appartment != null)
                {
                    result.Append(address.Appartment);
                    result.Append(" - ");
                }

            }
            return result.ToString();
        }
    }
}
