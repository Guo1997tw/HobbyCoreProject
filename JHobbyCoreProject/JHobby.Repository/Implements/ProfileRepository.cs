using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JHobby.Repository.Implements
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly JhobbyContext _jobbycontext;
        public ProfileRepository(JhobbyContext jhobbyContext) 
        {
            _jobbycontext = jhobbyContext;
        }
		public ProfileDto GetById(int id)
		{
			var m = _jobbycontext.Members.FirstOrDefault(x => x.MemberId == id);
			if (m == null) return new ProfileDto();
			var f = _jobbycontext.Activities.Include(x => x.Scores).Where(x => x.MemberId == id)
				.SelectMany(x=>x.Scores.Select(z=>z.Fraction)).Average();
            var result = new ProfileDto
			{
				MemberId = m.MemberId,
				NickName = m.NickName,
				Gender = m.Gender,
				AcitveCity = m.AcitveCity,
				PersonalProfile = m.PersonalProfile,
				HeadShot = m.HeadShot,
				Fraction = f,				
			};			
			return result;
		}
	}
}
