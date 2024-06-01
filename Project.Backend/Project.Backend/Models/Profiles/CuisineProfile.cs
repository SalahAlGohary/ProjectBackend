using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Models.Profiles
{
    public class CuisineProfile : Profile
    {
        public CuisineProfile()
        {
            //CreateMap<Cuisine, CuisineDTO>().ReverseMap();

            CreateMap<Cuisine, CuisineDTO>()
           .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src =>
               $"https://localhost:7198/Images/Cuisine/{src.Name.ToLower()}.jpg"));

        }

    }
}
