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
			var m = _jobbycontext.Members.Include(x => x.Scores).FirstOrDefault(x => x.MemberId == id);
			var result = new ProfileDto
			{
				MemberId = m.MemberId,
				NickName = m.NickName,
				Gender = m.Gender,
				AcitveCity = m.AcitveCity,
				PersonalProfile = m.PersonalProfile,
				HeadShot = m.HeadShot,
				Fraction = m.Scores.Average(x=> x.Fraction),
				
			};			
			return result;
		}
	}
}
