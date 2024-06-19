using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Models.Profiles
{
    public class DietTypeProfile : Profile
    {
        public DietTypeProfile()
        {
            //CreateMap<DietType, DietTypeDTO>().ReverseMap();
            CreateMap<DietType, DietTypeDTO>()
            .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src =>
             $"http://salahmohammed-001-site1.ctempurl.com/Images/DietType/{src.Id}.jpg"));

            //CreateMap<CreateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            //CreateMap<UpdateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

        }

    }
}
