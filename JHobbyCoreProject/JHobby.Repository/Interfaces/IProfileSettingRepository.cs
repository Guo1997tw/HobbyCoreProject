using JHobby.Repository.Models.Dto;

namespace JHobby.Repository.Interfaces
{
    public interface IProfileSettingRepository //功能
    {
        public ProfileSettingDto? GetById(int id);
        public bool Insert(ProfileSettingDto createProfileSettingDto);

        public bool Update(int id, ProfileSettingDto updateProfileSettingDto);

        public bool Delete(int id);
    }
}
