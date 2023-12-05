using AutoMapper;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;

namespace JHobby.Repository.Mapping;

public class RepositoryProfile : Profile
{
    public RepositoryProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryCreateDto, Category>();
		CreateMap<Member, MemberStatusDto>();
        CreateMap<CategoryUpdateDto, Category>();
        CreateMap<ActivityCreateDto, Activity>();
        CreateMap<Wish, WishDto>();
        CreateMap<WishCreateDto, Wish>();
        CreateMap<Activity, ActivityPageDto>();
        CreateMap<ActivityImage, ActivityPageDto>();
        CreateMap<Member, MemberResetDto>().ReverseMap();
    }
}