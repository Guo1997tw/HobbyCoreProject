using AutoMapper;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;

namespace JHobby.Website.Mapping
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            CreateMap<CategoryModel, CategoryViewModel>();
            CreateMap<ActivityPageModel, ActivityPageViewModel>();
            CreateMap<MemberStatusModel, MemberStatusViewModel>();
            CreateMap<ActivityConditionModel, ActivityConditionViewModel>().ReverseMap();
        }
    }
}