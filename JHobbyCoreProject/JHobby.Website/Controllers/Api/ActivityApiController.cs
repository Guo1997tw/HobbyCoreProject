using AutoMapper;
using AutoMapper.Execution;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Service.Models.Dto;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ActivityApiController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;
        string _Path;

        public ActivityApiController(IActivityService activityService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _activityService = activityService;
            _mapper = mapper;
            _Path = $@"{webHostEnvironment.WebRootPath}\profile\";
        }

        FileInfo[] GetFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_Path);
            FileInfo[] files = directoryInfo.GetFiles();
            return files;
        }

        [HttpPost]
        public bool InsertActivity(ActivityBuildViewModel activityBuildViewModel)
        {
            //        foreach (var activityBuildViewModel.File in activityBuildViewModel)
            //{
            var resultA = new ActivityBuildModel
            {
                ActivityCity = activityBuildViewModel.ActivityCity,
                ActivityArea = activityBuildViewModel.ActivityArea,
                ActivityLocation = activityBuildViewModel.ActivityLocation,
                StartTime = activityBuildViewModel.StartTime,
                MaxPeople = activityBuildViewModel.MaxPeople,
                CategoryId = activityBuildViewModel.CategoryId,
                CategoryTypeId = activityBuildViewModel.CategoryTypeId,
                JoinDeadLine = activityBuildViewModel.JoinDeadLine,
                JoinFee = activityBuildViewModel.JoinFee,
                ActivityNotes = activityBuildViewModel.ActivityNotes,
                MemberId = activityBuildViewModel.MemberId,
                ActivityStatus = activityBuildViewModel.ActivityStatus,
                Payment = activityBuildViewModel.Payment,
                Created = activityBuildViewModel.Created
            };

            _activityService.CreateActivityBuild(resultA);


            //foreach (var activityBuildViewModel.File in activityBuildViewModel)
            //{
            if (activityBuildViewModel.File != null)
            {
                if (activityBuildViewModel.File.Length > 0)
                {
                    string SavePath = $@"{_Path}{activityBuildViewModel.File.FileName}";

                    using (var steam = new FileStream(SavePath, FileMode.Create))
                    {
                        activityBuildViewModel.File.CopyToAsync(steam);
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// 活動頁面查詢
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ActivityPageViewModel> ActivitySearch(int id)
        {
            var result = _activityService.GetActivityPageSearch(id);

            var mapper = new ActivityPageViewModel
            {
                ActivityId = result.ActivityId,
                MemberId = result.MemberId,
                ActivityLocation = result.ActivityLocation,
                CategoryId = result.CategoryId,
                CategoryTypeId = result.CategoryTypeId,
                ActivityName = result.ActivityName,
                StartTime = result.StartTime,
                JoinDeadLine = result.JoinDeadLine,
                ActivityNotes = result.ActivityNotes,
                ActivityImages = result.ActivityImages.Select(ai => new ActivityImageViewModel
                {
                    ActivityImageId = ai.ActivityImageId,
                    AiActivity = ai.AiActivity,
                    ImageName = ai.ImageName,
                    IsCover = ai.IsCover,
                    UploadTime = ai.UploadTime,
                })
            };

            return Ok(mapper);
        }

        /// <summary>
        /// 會員留言板查詢
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MemberMsgViewModel>> MemberMsg(int id)
        {
            return Ok(_activityService.GetMemberMsg(id));
        }

        /// <summary>
        /// 會員留言板新增
        /// </summary>
        /// <param name="memberInsertMsgViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MemberCreateMsg([FromForm] MemberInsertMsgViewModel memberInsertMsgViewModel)
        {
            var mapper = new MemberInsertMsgModel
            {
                MemberId = memberInsertMsgViewModel.MemberId,
                ActivityId = memberInsertMsgViewModel.ActivityId,
                MessageTime = memberInsertMsgViewModel.MessageTime,
                MessageText = memberInsertMsgViewModel.MessageText,
            };

            _activityService.CreateMsg(mapper);

            return Ok("新增成功");
        }

        /// <summary>
        /// 查詢會員活動申請者是否已參團或本身是開團者
        /// </summary>
        /// <returns></returns>
        [HttpGet("{memberId}/{activityId}")]
        public bool GetMemberJoinStatus(int memberId, int activityId)
        {
            return _activityService.GetMemberStatus(memberId, activityId);
        }

        /// <summary>
        /// 活動申請
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public bool ActivityUserCreate([FromForm] ActivityUserInsertViewModel activityUserInsertViewModel)
        {
            var mapper = new ActivityUserInsertModel
            {
                MemberId = activityUserInsertViewModel.MemberId,
                ActivityId = activityUserInsertViewModel.ActivityId,
                ReviewStatus = activityUserInsertViewModel.ReviewStatus,
                ReviewTime = activityUserInsertViewModel.ReviewTime,
            };
            if (!_activityService.CreateActivityUser(mapper))
            {
                return false;
            }
            return true;
        }

    }
}
