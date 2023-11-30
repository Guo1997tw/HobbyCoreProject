using AutoMapper;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;

namespace JHobby.Repository.Mapping;

public class RepositoryProfile : Profile
{
    public RepositoryProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryCreateDto>();
        CreateMap<Category, CategoryUpdateDto>();

        CreateMap<Activity, ActivityCreateDto>();

        CreateMap<Wish, WishDto>();
        CreateMap<Wish, WishCreateDto>();
    }
}