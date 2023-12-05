using JHobby.Service.Implements;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [EnableCors("allowCors")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PastJoinAGroupApiController : ControllerBase
    {
        private readonly IPastJoinAGroupService _aPastJoinAGroupService;

        public PastJoinAGroupApiController(IPastJoinAGroupService astJoinAGroupService)
        {
            _aPastJoinAGroupService = astJoinAGroupService;
        }

        [HttpGet]
        public IEnumerable<PastJoinAGroupViewModel> GetPastJoinAGroupAll()
        {
            return _aPastJoinAGroupService.GetPastJoinAGroupAll().Select(x => new PastJoinAGroupViewModel
            {
                ActivityCity = x.ActivityCity,
                ActivityName = x.ActivityName,
                ActivityStatus = x.ActivityStatus,
                CurrentPeople = x.CurrentPeople,
                NickName = x.NickName,
                DateConvert = x.DateConvert,
                TimeConvert = x.TimeConvert,
            });

        }

        [HttpGet]
        public IEnumerable<PastJoinAGroupViewModel> GetPastJoinAGroupById(int memberId)
        {
            return _aPastJoinAGroupService.GetPastJoinAGroupById(memberId)
                .Select(x => new PastJoinAGroupViewModel
                {
                    ActivityId = x.ActivityId,
                    ActivityCity = x.ActivityCity,
                    ActivityName = x.ActivityName,
                    ActivityStatus = x.ActivityStatus,
                    CurrentPeople = x.CurrentPeople,
                    NickName = x.NickName,
                    MemberId = x.MemberId,
                    DateConvert = x.DateConvert,
                    TimeConvert = x.TimeConvert,
                    Fraction = x.Fraction,
                });
        }
    }
}
