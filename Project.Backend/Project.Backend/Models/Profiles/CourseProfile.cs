﻿using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Models.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            //CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>()
           .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src =>
               $"http://salahmohammed-001-site1.ctempurl.com/Images/Course/{src.Id}.jpg"));

            //CreateMap<CreateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            //CreateMap<UpdateRecipeDto, FoodRecipe>()
            //    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

        }

    }
}
