using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProfileSettingApiController : ControllerBase
    {
        private readonly IProfileSettingService _iProfileSettingService;

		public ProfileSettingApiController(IProfileSettingService iProfileSettingService)
        {
            _iProfileSettingService = iProfileSettingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProfileSettingViewModel>> GetProfileSettingViewAll(int id)
        {
            var serviceModel = _iProfileSettingService.GetByIdService(id); //GetByIdService

            var viewModel = serviceModel.Select(m => new ProfileSettingViewModel
            {
                HeadShot = m.HeadShot,
                Status = m.Status,
                MemberId = m.MemberId,
                MemberName = m.MemberName,
                NickName = m.NickName,
                Gender = m.Gender,
                IdentityCard = m.IdentityCard,
                Birthday = m.Birthday,
                AcitveCity = m.AcitveCity,
                ActiveArea = m.ActiveArea,
                Address = m.Address,
                Phone = m.Phone,
                PersonalProfile = m.PersonalProfile
            });

            return Ok(viewModel);
        }
    }
}