using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos.Recipe;

namespace Project.Backend.Models.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<FoodRecipe, GetRecipeDto>().ReverseMap();

            CreateMap<CreateRecipeDto, FoodRecipe>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdateRecipeDto, FoodRecipe>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

        }

    }
}
