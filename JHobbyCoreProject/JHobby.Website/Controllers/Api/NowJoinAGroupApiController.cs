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
                    ActivityUserId = s.ActivityUserId,
                    MemberId = s.MemberId,
                    ReviewStatus = s.ReviewStatus,
                    CurrentPeople = s.CurrentPeople,
                    MaxPeople = s.MaxPeople,
                    NickName = s.NickName,
                    DateConvert = s.DateConvert,
                    TimeConvert = s.TimeConvert,
                    ImageName = s.ImageName,
                }
            );
        }

        [HttpGet]
        public PageFilterViewModel<NowJoinAGroupViewModel> GetNowJoinAGroupById(int memberId, int pageNumber, int countPerPage = 3)
        {
            var queryResult = _aNowJoinAGroupService.GetNowJoinAGroupById(memberId, pageNumber, countPerPage);

            if (queryResult != null)
            {
                return new PageFilterViewModel<NowJoinAGroupViewModel>
                {
                    PageNumber = queryResult.PageNumber,
                    TotalPages = queryResult.TotalPages,
                    Items = queryResult.Items.Select(s => new NowJoinAGroupViewModel
                    {
                        ActivityUserId = s.ActivityUserId,
                        ActivityId = s.ActivityId,
                        MemberId = s.MemberId,
                        ActivityName = s.ActivityName,
                        ReviewStatus = s.ReviewStatus,
                        CurrentPeople = s.CurrentPeople,
                        MaxPeople = s.MaxPeople,
                        NickName = s.NickName,
                        DateConvert = s.DateConvert,
                        TimeConvert = s.TimeConvert,
                        ImageName = s.ImageName,
                    })
                };
            }
            else
            {
                return new PageFilterViewModel<NowJoinAGroupViewModel>
                {
                    PageNumber = 0,
                    TotalPages = 0,
                    Items = new List<NowJoinAGroupViewModel>
                    {
                        new NowJoinAGroupViewModel
                        {
                             ActivityUserId = 0,
                             ActivityId = 0,
                             MemberId = 0,
                             ActivityName = null,
                             ReviewStatus = null,
                             CurrentPeople = 0,
                             MaxPeople = 0,
                             NickName = null,
                             DateConvert = null,
                             TimeConvert = null,
                             ImageName = null,
                        }
                    }
                };
            }

        }

        [HttpPut("{activityId}/{memberId}")]
        public ActionResult NowJoinAGroupCancel(int activityId, int memberId, [FromForm] NowJoinAGroupCancelViewModel nowJoinAGroupCancel)
        {
            var mapping = new NowJoinAGroupCancelModel
            {
                ReviewStatus = nowJoinAGroupCancel.ReviewStatus,
            };

            _aNowJoinAGroupService.NowJoinAGroupCancel(activityId, memberId, mapping);
            return Ok("修改成功");
        }
    }
}
