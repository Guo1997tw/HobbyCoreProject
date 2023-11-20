using JHobby.Repository.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
    public interface IProfileSettingService
    {
        public interface IProfileSettingService //功能
        {
            public ProfileSettingDto? GetById(int id);
            public bool Insert(ProfileSettingDto createProfileSettingDto);

            public bool Update(int id, ProfileSettingDto updateProfileSettingDto);

            public bool Delete(int id);
        }
    }
}
