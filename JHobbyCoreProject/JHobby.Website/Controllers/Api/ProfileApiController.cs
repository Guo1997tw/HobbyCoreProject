using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JHobby.Website.Controllers.Api
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class ProfileApiController : ControllerBase
	{
		private readonly IProfileService _profileService;
		
		public ProfileApiController(IProfileService profileService)
		{
			_profileService = profileService;
		}

		// GET: api/<ProfileApiController>
		[HttpGet("{id}")]
		public ProfileViewModel GetProfileById(int id)     //ById拿團主資料API
		{
			var servicesDto = _profileService.GetProfileById(id);
			return new ProfileViewModel
			{
				MemberId = servicesDto.MemberId,
				NickName = servicesDto.NickName,
				Gender = servicesDto.Gender,
				AcitveCity = servicesDto.AcitveCity,
				PersonalProfile = servicesDto.PersonalProfile,
				HeadShot = servicesDto.HeadShot,
				Fraction = servicesDto.Fraction,
			};
		}
		[HttpGet("{id}")]
		public IEnumerable<ProfilePastActivityViewModel> GetPastActivity(int id)
		{
			var res=_profileService.GetPastActivity(id);
			var result = res.Select(a => new ProfilePastActivityViewModel
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
                DateConvert = a.DateConvert,
                TimeConvert = a.TimeConvert,
            });
			return result;
		}

    }
}
