using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [EnableCors("allowCors")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class NowJoinAGroupApiController : ControllerBase
    {
        private readonly INowJoinAGroupService _anowJoinAGroupService;

        public NowJoinAGroupApiController(INowJoinAGroupService anowJoinAGroupService)
        {
            _anowJoinAGroupService = anowJoinAGroupService;
        }

        [HttpGet]
        public IEnumerable<NowJoinAGroupViewModel> GetNowJoinAGroupAll()
        {
            return _anowJoinAGroupService.GetNowJoinAGroupAll()
                .Select(s => new NowJoinAGroupViewModel
                {
                    ActivityName = s.ActivityName,
                    ReviewStatus = s.ReviewStatus,
                    ReviewTime = s.ReviewTime,
                    CurrentPeople = s.CurrentPeople,
                    MaxPeople = s.MaxPeople,
                    StartTime = s.StartTime,
                    NickName = s.NickName,
                }
            );
        }
    }
}
