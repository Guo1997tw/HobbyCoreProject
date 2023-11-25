using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [Route("api/ProfileSetting/[action]")]
    [ApiController]
    public class ProfileSettingApiController : ControllerBase
    {
        private readonly IProfileSettingService _iProfileSettingService;

		public ProfileSettingApiController(IProfileSettingService iProfileSettingService)
        {
            _iProfileSettingService = iProfileSettingService;
        }

        [HttpGet("{id}")]
        public ActionResult<ProfileSettingViewModel> GetById(int id)
        {
            var serviceModel = _iProfileSettingService.GetById(id); //GetByIdService

			var viewModel = new ProfileSettingViewModel
			{
				HeadShot = serviceModel.HeadShot,
				Status = serviceModel.Status,
				MemberId = serviceModel.MemberId,
				MemberName = serviceModel.MemberName,
				NickName = serviceModel.NickName,
				Gender = serviceModel.Gender,
				IdentityCard = serviceModel.IdentityCard,
				Birthday = serviceModel.Birthday,
				AcitveCity = serviceModel.AcitveCity,
				ActiveArea = serviceModel.ActiveArea,
				Address = serviceModel.Address,
				Phone = serviceModel.Phone,
				PersonalProfile = serviceModel.PersonalProfile
			};
			return Ok(viewModel);
        }
    }
}