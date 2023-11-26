using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
    public interface IProfileSettingService//顯示會員資訊介面Service
    {
        public ProfileSettingModel GetById(int id);

		//public bool Update(int id, ProfileSettingDto updateProfileSettingDto);

	}
}
