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
    public class ProfileRepository : IProfileRepository
    {
        private readonly JhobbyContext _jobbycontext;
        public ProfileRepository(JhobbyContext jhobbyContext) 
        {
            _jobbycontext = jhobbyContext;
        }

        public IEnumerable<ProfileDto> GetAll()
        {
            var result = _jobbycontext.Members.Select(x => new ProfileDto
            {
                MemberId = x.MemberId,
                NickName = x.NickName,
                Gender = x.Gender,
                AcitveCity = x.AcitveCity,
                PersonalProfile = x.PersonalProfile,
            });
            return result;
        }

        public ProfileDto GetById(int id)
        {
            var result=_jobbycontext.Members.FirstOrDefault(x=>x.MemberId == id);
            var profileDto = new ProfileDto
            {
                MemberId =result.MemberId,
                NickName=result.NickName,
                Gender = result.Gender,
                AcitveCity=result.AcitveCity,
                PersonalProfile = result.PersonalProfile,
            };
            return profileDto;
        }
    }
}
