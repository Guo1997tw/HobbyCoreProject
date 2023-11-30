using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JHobby.Repository.Implements.UpdateProfileSettingRepository;

namespace JHobby.Repository.Implements
{
    public class UpdateProfileSettingRepository : IUpdateProfileSettingRepository
    {
        private readonly JhobbyContext _jhobbyContext;

        public UpdateProfileSettingRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext = jhobbyContext;
        }
        public bool Update(int id, UpdateProfileSettingDto updateProfileSettingDto)
        {
            var queryResult = _jhobbyContext.Members.FirstOrDefault(m => m.MemberId == id);

            if (queryResult != null)
            {
                queryResult.HeadShot = updateProfileSettingDto.HeadShot;
                queryResult.Status = updateProfileSettingDto.Status;
                queryResult.MemberName = updateProfileSettingDto.MemberName;
                queryResult.NickName = updateProfileSettingDto.NickName;
                queryResult.Gender = updateProfileSettingDto.Gender;
                queryResult.IdentityCard = updateProfileSettingDto.IdentityCard;
                queryResult.Birthday = updateProfileSettingDto.Birthday;
                queryResult.ActiveCity = updateProfileSettingDto.ActiveCity;
                queryResult.ActiveArea = updateProfileSettingDto.ActiveArea;
                queryResult.Address = updateProfileSettingDto.Address;
                queryResult.Phone = updateProfileSettingDto.Phone;
                queryResult.PersonalProfile = updateProfileSettingDto.PersonalProfile;

                _jhobbyContext.SaveChanges();

                return true;
            };

            return false;
        }
    }
}
