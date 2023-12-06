using AutoMapper;
using AutoMapper.Execution;
using JHobby.Repository.Interfaces;
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
        private readonly string _rootPath;
        

        public ActivityApiController(IActivityService activityService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _activityService = activityService;
            _mapper = mapper;
            _rootPath = $@"{webHostEnvironment.WebRootPath}\activityImages\";
        }

        /// <summary>
        /// 團主建立
        /// </summary>
        /// <param name="activityCreateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> LeaderCreate([FromForm] ActivityCreateViewModel activityCreateViewModel)
        {
            var picPathList = new List<string>();
            var activityCreateModel = _mapper.Map<ActivityCreateModel>(activityCreateViewModel);

            if (activityCreateViewModel.File != null)
            {
                var i = 1;

                foreach (var file in activityCreateViewModel.File)
                {
                    var fileName = file.FileName;
                    fileName = $"activity{i}.jpg";
                    var filePath = $"{_rootPath}{fileName}";
                    var fullFileName = $"\\activityImages\\{fileName}";

                    using var fs = new FileStream(filePath, FileMode.Create);

                    await file.CopyToAsync(fs);

                    picPathList.Add(fullFileName);

                    i++;
                }
            }

            activityCreateModel.ActivityImages = picPathList.Select(x => new ActivityImageCreateModel
            { ImageName = x }).ToList();

            var result = _activityService.ActivityCreate(activityCreateModel);

            return result;
        }

        /// <summary>
        /// 團主編輯
        /// </summary>
        /// <param name="id"></param>
        /// <param name="activityUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public bool LeaderUpdate([FromForm] ActivityUpdateViewModel activityUpdateViewModel)
        {
            var mapper = _mapper.Map<ActivityUpdateModel>(activityUpdateViewModel);

            return (_activityService.ActivityUpdate(mapper)) ? true : false;
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