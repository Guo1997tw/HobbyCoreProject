using JHobby.Service.Interfaces;
using JHobby.Service.Models;
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
        private readonly INowJoinAGroupService _aNowJoinAGroupService;

        public NowJoinAGroupApiController(INowJoinAGroupService anowJoinAGroupService)
        {
            _aNowJoinAGroupService = anowJoinAGroupService;
        }

        [HttpGet]
        public IEnumerable<NowJoinAGroupViewModel> GetNowJoinAGroupAll()
        {
            return _aNowJoinAGroupService.GetNowJoinAGroupAll()
                .Select(s => new NowJoinAGroupViewModel
                {
                    ActivityName = s.ActivityName,
                    ReviewStatus = s.ReviewStatus,
                    ReviewTime = s.ReviewTime,
                    CurrentPeople = s.CurrentPeople,
                    MaxPeople = s.MaxPeople,
                    StartTime = s.StartTime,
                    NickName = s.NickName,
                    DateConvert = s.DateConvert,
                    TimeConvert = s.TimeConvert,
                }
            );
        }

        [HttpGet]
        public IEnumerable<NowJoinAGroupViewModel> GetNowJoinAGroupById(int memberId)
        {
            return _aNowJoinAGroupService.GetNowJoinAGroupById(memberId)
                .Select(s => new NowJoinAGroupViewModel
                {
                    ActivityName = s.ActivityName,
                    ReviewStatus = s.ReviewStatus,
                    ReviewTime = s.ReviewTime,
                    CurrentPeople = s.CurrentPeople,
                    MaxPeople = s.MaxPeople,
                    StartTime = s.StartTime,
                    NickName = s.NickName,
                    DateConvert = s.DateConvert,
                    TimeConvert = s.TimeConvert,
                }
            );
        }

        [HttpPut("{activityUserId}/{memberId}")]
        public ActionResult NowJoinAGroupCancel(int activityUserId, int memberId, [FromForm] NowJoinAGroupCancelViewModel nowJoinAGroupCancel)
        {
            var mapping = new NowJoinAGroupCancelModel
            {
                ReviewStatus = nowJoinAGroupCancel.ReviewStatus,
            };

            _aNowJoinAGroupService.NowJoinAGroupCancel(activityUserId, memberId, mapping);
            return Ok("修改成功");
        }
    }
}
