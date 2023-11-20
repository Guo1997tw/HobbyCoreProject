using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;

namespace JHobby.Repository.Implements
{
    public class ProfileSettingService : IProfileSettingService
    {
        private readonly JhobbyContext _jhobbyContext;

        public ProfileSettingService(JhobbyContext jhobbyContext)
        {
            _jhobbyContext = jhobbyContext;
        }
        public ProfileSettingDto GetById(int id)
        {
            // 使用 FirstOrDefault 以確保不會返回空值
            var queryResult = _jhobbyContext.Members
                .Where(m => m.MemberId == id)
                .Select(m => new ProfileSettingDto
                {
                    HeadShot = m.HeadShot,
                    Status = m.Status,
                    MemberId = m.MemberId,
                    MemberName = m.MemberName,
                    NickName = m.NickName,
                    Gender = m.Gender,

                    // 其他需要的資料
                })
                .FirstOrDefault();

            return queryResult;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }


        public bool Insert(ProfileSettingDto createProfileSettingDto)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, ProfileSettingDto updateProfileSettingDto)
        {
            throw new NotImplementedException();
        }
    }
}
