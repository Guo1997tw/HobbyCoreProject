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
        public IEnumerable<ProfileViewModel> GetProfileById(int id)     //拿團主資料API
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

        //GET api/<ProfileApiController>/5
        //[HttpGet("{id}")]
        //public async Task<IEnumerable<ProfileModel>> GetProfileById(int id)
        //{

        //}

        //POST api/<ProfileApiController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //PUT api/<ProfileApiController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //DELETE api/<ProfileApiController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
