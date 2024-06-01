using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Models.Profiles
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            //CreateMap<Collection, CollectionDTO>().ReverseMap();
            CreateMap<Collection, CollectionDTO>()
          .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src =>
              $"https://localhost:7198/Images/Collection/{src.Name.ToLower()}.jpg"));
            //CreateMap<CreateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            //CreateMap<UpdateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

        }

    }
}
