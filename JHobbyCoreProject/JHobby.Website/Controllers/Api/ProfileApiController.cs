using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public IEnumerable<ProfileViewModel> GetProfileById(int id)     //ById拿團主資料API
        {
            var servicesDto = _profileService.GetProfileById(id);
            var viewModel = new ProfileViewModel
            {
                MemberId = servicesDto.MemberId,
                NickName = servicesDto.NickName,
                Gender = servicesDto.Gender,
                AcitveCity = servicesDto.AcitveCity,
                PersonalProfile = servicesDto.PersonalProfile,
            };
            yield  return viewModel;  
        }
    }
}
