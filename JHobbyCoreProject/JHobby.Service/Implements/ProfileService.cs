using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JHobby.Repository.Implements;
using JHobby.Repository.Interfaces;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
    public class ProfileService: IProfileService
	{
        private readonly IProfileRepository _profileRepository;
        public ProfileService (IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        

        public ProfileModel GetProfileById(int id)
        {
            var res=_profileRepository.GetById(id);
            
			if(res.Fraction == null) res.Fraction = 0;

			return new ProfileModel
			{
				MemberId = res.MemberId,
				NickName = res.NickName,
				Gender = res.Gender,
				AcitveCity = res.AcitveCity,
				PersonalProfile =res.PersonalProfile,
				HeadShot = res.HeadShot,
				Fraction = res.Fraction				
			};
        }

		
	}
}
