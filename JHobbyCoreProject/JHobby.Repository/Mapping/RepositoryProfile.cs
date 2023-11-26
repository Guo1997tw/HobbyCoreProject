using AutoMapper;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Mapping
{
    public class RepositoryProfile : Profile
    {
        public RepositoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Activity, ActivityPageDto>();
        }
    }
}