using AutoMapper;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
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
            CreateMap<ActivityStatusModel, ActivityStatusViewModel>().ReverseMap();
            CreateMap<ActivityCreateViewModel, ActivityCreateModel>();
            CreateMap<ActivityUpdateViewModel, ActivityUpdateModel>();
            CreateMap<MemberResetModel, MemberResetViewModel>().ReverseMap();
            CreateMap<CategoryTypeModel, CategoryTypeViewModel>().ReverseMap();
            CreateMap<CategoryDetailModel, CategoryDetailViewModel>().ReverseMap();
        }
    }
}