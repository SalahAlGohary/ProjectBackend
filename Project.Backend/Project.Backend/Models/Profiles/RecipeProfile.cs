﻿using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Models.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {

            CreateMap<FoodRecipe, RecipeDTO>()
                 .ForMember(dest => dest.NutritionInfos, opt => opt.MapFrom(src => GetNutritionInfos(src.FoodRecipeNutritionInfos.Select(x => x.NutritionInfo).ToList())))
                 .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => GetIngredients(src.FoodRecipeIngredients.Select(x => x.Ingredient).ToList())))
                 .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => GetKeywords(src.FoodRecipeKeywords.Select(x => x.Keyword).ToList())))
                 .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src => $"https://localhost:7198/Images/Recipe/{src.Id}.jpg"))
                 .ReverseMap();
            //CreateMap<CreateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            //CreateMap<UpdateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

        }
        private List<string> GetNutritionInfos(List<NutritionInfo> nutritionInfos)
        {
            if (nutritionInfos == null || !nutritionInfos.Any())
            {
                return null;
            }

            var nutritionInfoList = nutritionInfos.Select(x => x.Name).ToList();
            return nutritionInfoList;
        }

        private List<string> GetIngredients(List<Ingredient> ingredients)
        {
            if (ingredients == null || !ingredients.Any())
            {
                return null;
            }

            var ingredientsList = ingredients.Select(x => x.Name).ToList();
            return ingredientsList;
        }
        private List<string> GetKeywords(List<Keyword> Keywords)
        {
            if (Keywords == null || !Keywords.Any())
            {
                return null;
            }

            var KeywordList = Keywords.Select(x => x.Name).ToList();
            return KeywordList;
        }

    }
}
