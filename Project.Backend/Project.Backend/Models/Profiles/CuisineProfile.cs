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
               $"http://salahmohammed-001-site1.ctempurl.com/Images/Cuisine/{src.Id}.jpg"));

        }

    }
}
