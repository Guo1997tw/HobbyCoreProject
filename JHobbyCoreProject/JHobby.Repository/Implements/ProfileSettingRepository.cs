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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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

        public bool Insert(ProfileSettingDto createProfileSettingDto)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, ProfileSettingDto updateProfileSettingDto)
        {
            throw new NotImplementedException();
        }

        //public bool Update(int id, ProfileSettingDto updateProfileSettingDto)
        //{
        //    var queryResult = _jhobbyContext.ProfileSetting.FirstOrDefault(m => m.MemberId == id);

        //    if (queryResult != null)
        //    {
        //        queryResult.CategoryName = updateCategoryDto.CategoryName;

        //        _jhobbyContext.SaveChanges();

        //        return true;
        //    };

        //    return false;
        //}
    }
}
