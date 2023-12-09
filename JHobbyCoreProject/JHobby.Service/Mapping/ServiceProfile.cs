using AutoMapper;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<CategoryDto, CategoryModel>();
			CreateMap<CategoryCreateDto, CreateCategoryModel>();
            CreateMap<ActivityPageDto, ActivityPageModel>();
            CreateMap<MemberStatusDto, MemberStatusModel>();
			CreateMap<ActivityStatusDto, ActivityStatusModel>().ReverseMap();
            CreateMap<ActivityConditionDto, ActivityConditionModel>().ReverseMap();
            CreateMap<ActivityCreateModel, ActivityCreateDto>();
            CreateMap<ActivityImageCreateModel, ActivityImageCreateDto>();
            CreateMap<ActivityUpdateModel, ActivityUpdateDto>();
            //CreateMap<ActivityCreateDto, ActivityCreateModel>()
            //    .ForMember(dest=>dest.ActivityImages,opt=>opt.MapFrom(src=> src.ActivityImages.Select(x=>x.ImageName)));
            CreateMap<MemberResetDto, MemberResetModel>().ReverseMap();
            CreateMap<CategoryTypeDto, CategoryTypeModel>().ReverseMap();
            CreateMap<CategoryDetailDto, CategoryDetailModel>().ReverseMap();
        }
    }
}