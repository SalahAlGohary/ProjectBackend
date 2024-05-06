using AutoMapper;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos.Dish;

namespace Project.Backend.Models.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, GetDishDto>();

            CreateMap<CreateDishDto, Dish>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdateDishDto, Dish>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

        }

    }
}
