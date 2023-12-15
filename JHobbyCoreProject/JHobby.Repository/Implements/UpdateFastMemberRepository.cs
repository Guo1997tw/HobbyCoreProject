using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
    public class UpdateFastMemberRepository:IUpdateFastMemberRepository
    {
        public readonly JhobbyContext _jhobbyContext;
        public UpdateFastMemberRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext=jhobbyContext;
        }

        public bool Update(int id, UpdateFastMemberDto updateFastMemberDto)
        {
            var queryResult = _jhobbyContext.Members.FirstOrDefault(m => m.MemberId == id);

            if (queryResult != null)
            {
                queryResult.HeadShot = updateFastMemberDto.HeadShot;
                queryResult.MemberName = updateFastMemberDto.MemberName;
                queryResult.NickName = updateFastMemberDto.NickName;
                queryResult.Gender = updateFastMemberDto.Gender;
                queryResult.IdentityCard = updateFastMemberDto.IdentityCard;
                queryResult.Birthday = updateFastMemberDto.Birthday;
                queryResult.Status = updateFastMemberDto.Status;
                queryResult.ActiveCity = updateFastMemberDto.ActiveCity;
                queryResult.ActiveArea = updateFastMemberDto.ActiveArea;
                queryResult.Address = updateFastMemberDto.Address;
                queryResult.Phone = updateFastMemberDto.Phone;
                queryResult.PersonalProfile = updateFastMemberDto.PersonalProfile;

                _jhobbyContext.SaveChanges();

                return true;
            };
            return false;
        }
    }
}
