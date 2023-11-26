using JHobby.Service.Implements;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PastJoinAGroupApiController : ControllerBase
    {
        private readonly IPastJoinAGroupService _astJoinAGroupService;

        public PastJoinAGroupApiController(IPastJoinAGroupService astJoinAGroupService)
        {
            _astJoinAGroupService = astJoinAGroupService;
        }

        [HttpGet]
        public IEnumerable<PastJoinAGroupViewModel> GetPastJoinAGroupAll()
        {
            return _astJoinAGroupService.GetPastJoinAGroupAll().Select(x=> new PastJoinAGroupViewModel 
            {
                ActivityCity = x.ActivityCity,
                ActivityName = x.ActivityName,
                ActivityStatus  = x.ActivityStatus,
                CurrentPeople = x.CurrentPeople,
                NickName = x.NickName,
                StartTime = x.StartTime,
            });

        }
    }
}
