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
        private readonly ICommonService _commonService;
        public ProfileService (IProfileRepository profileRepository,ICommonService commonService)
        {
            _profileRepository = profileRepository;
            _commonService = commonService;
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
				Fraction = Math.Round((decimal)res.Fraction,1)
			};
        }
		public IEnumerable<ProfilePastActivityModel> GetPastActivity(int id)
        {
            var result=_profileRepository.GetPastActivity(id);
            var res = result.Select(a => new ProfilePastActivityModel
            {
                MemberId = a.MemberId,
                ActivityName = a.ActivityName,
                ActivityId = a.ActivityId,
                ActivityStatus = a.ActivityStatus,
                IsCover = a.IsCover,
                ImageName = a.ImageName,
                ActivityCity = a.ActivityCity,
                ActivityNotes = a.ActivityNotes,
                StartTime = a.StartTime,
                DateConvert = _commonService.ConvertTime(a.StartTime).First().DateConvert,
                TimeConvert=_commonService.ConvertTime(a.StartTime).First().TimeConvert,
            });
            return res;
        }



    }
}
