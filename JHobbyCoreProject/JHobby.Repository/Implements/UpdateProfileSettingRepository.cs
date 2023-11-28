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
                queryResult.HeadShot = updateProfileSettingDto.UpdatedHeadShot;
                queryResult.NickName = updateProfileSettingDto.UpdatedNickName;
                queryResult.ActiveCity = updateProfileSettingDto.UpdatedAcitveCity;
                queryResult.ActiveArea = updateProfileSettingDto.UpdatedActiveArea;
                queryResult.Address = updateProfileSettingDto.UpdatedAddress;
                queryResult.Phone = updateProfileSettingDto.UpdatedPhone;
                queryResult.PersonalProfile = updateProfileSettingDto.UpdatedPersonalProfile;

                _jhobbyContext.SaveChanges();

                return true;
            };

            return false;
        }
    }
}
