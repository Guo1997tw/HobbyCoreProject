using JHobby.Repository.Models.Dto;

namespace JHobby.Repository.Interfaces
{
    public interface IProfileSettingRepository //顯示會員資訊介面
    {
        public ProfileSettingDto GetById(int id);
	}
}
