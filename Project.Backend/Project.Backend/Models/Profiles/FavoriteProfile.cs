using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Models.Profiles
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {

            //CreateMap<Favorite, FavoriteDTO>()
            //     .ForMember(dest => dest.NutritionInfos, opt => opt.MapFrom(src => GetNutritionInfos(src.FoodRecipeNutritionInfos.Select(x => x.NutritionInfo).ToList())))
            //     .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => GetIngredients(src.FoodRecipeIngredients.Select(x => x.Ingredient).ToList())))
            //     .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => GetKeywords(src.FoodRecipeKeywords.Select(x => x.Keyword).ToList())))
            //     .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src => $"http://salahmohammed-001-site1.ctempurl.com/Images/Recipe/{src.Id}.jpg"))
            //     .ReverseMap();
            //CreateMap<CreateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            //CreateMap<UpdateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Favorite, FavoriteDTO>().ReverseMap();

        }


    }
}
