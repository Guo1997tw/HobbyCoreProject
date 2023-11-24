using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
    public class ProfileSettingRepository : IProfileSettingRepository
    {
        private readonly JhobbyContext _jhobbyContext;

        public ProfileSettingRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext = jhobbyContext;
        }

        public IEnumerable<ProfileSettingDto> GetById(int id)
        {
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
                    IdentityCard = m.IdentityCard,
                    Birthday = m.Birthday,
                    AcitveCity = m.AcitveCity,
                    ActiveArea = m.ActiveArea,
                    Address = m.Address,
                    Phone = m.Phone,
                    PersonalProfile = m.PersonalProfile,

                    // 其他需要的資料
                });

            return queryResult;
        }
    }
}
