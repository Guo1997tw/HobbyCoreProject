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
    public class UpdateGeneralMemberRepository : IUpdateGeneralMemberRepository
    {
        private readonly JhobbyContext _jhobbyContext;
        public UpdateGeneralMemberRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext= jhobbyContext;
        }

        public bool Update(int id, UpdateGeneralMemberDto updateGeneralMemberDto)
        {
            var queryResult = _jhobbyContext.Members.FirstOrDefault(m => m.MemberId == id);

            if (queryResult != null)
            {
                queryResult.HeadShot = updateGeneralMemberDto.HeadShot;
                queryResult.NickName = updateGeneralMemberDto.NickName;
                queryResult.ActiveCity = updateGeneralMemberDto.ActiveCity;
                queryResult.ActiveArea = updateGeneralMemberDto.ActiveArea;
                queryResult.Address = updateGeneralMemberDto.Address;
                queryResult.PersonalProfile = updateGeneralMemberDto.PersonalProfile;

                _jhobbyContext.SaveChanges();

                return true;
            };
            return false;
        }
    }
}
