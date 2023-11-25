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
        public ActionResult<IQueryable<PastJoinAGroupViewModel>> GetPastJoinAGroupsListAll(int page, int pageSize)
        {
            if(page >= 1)
            {
            var data = _astJoinAGroupService.GetPastJoinAGroupsList(page, pageSize).ToList();

            return Ok(data);
            }
            else { return null; }
            
        }
        [HttpGet]
        public IEnumerable<PastJoinAGroupViewModel> GetAll()
        {
            return _astJoinAGroupService.GetAll().Select(x=> new PastJoinAGroupViewModel 
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
