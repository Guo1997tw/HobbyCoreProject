using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
    public class ActivityService : IActivityService
    {
        public readonly IActivityRepository _activityRepository;
        public readonly IMapper _mapper;
        public readonly ICommonService _commonService;
        public ActivityService(IActivityRepository activityRepository, IMapper mapper, ICommonService commonService)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
            _commonService = commonService;
        }

        /// <summary>
        /// 團主建立
        /// </summary>
        /// <param name="activityCreateModel"></param>
        /// <returns></returns>
        public bool ActivityCreate(ActivityCreateModel activityCreateModel)
        {
            var result = _mapper.Map<ActivityCreateDto>(activityCreateModel);

            return _activityRepository.ActivityBuild(result);
        }

        /// <summary>
        /// 團主編輯
        /// </summary>
        /// <param name="activityUpdateModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ActivityUpdate(int id, ActivityUpdateModel activityUpdateModel)
        {
            var result = _mapper.Map<ActivityUpdateDto>(activityUpdateModel);

            return (_activityRepository.ActivityUpdate(id, result)) ? true : false;
        }

        /// <summary>
        /// 取得開團資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ActivityStatusModel GetActivityStatus(int id)
        {
            var result = _activityRepository.ActivityStatus(id);

            if (result == null) { return null; }

            return _mapper.Map<ActivityStatusModel>(result);
        }

        /// <summary>
        /// 活動頁面查詢
        /// </summary>
        /// <param name="id"></param>
        /// <param name="activityName"></param>
        /// <returns></returns>
        public ActivityPageModel GetActivityPageSearch(int id)
        {
            var result = _activityRepository.GetActivityPageById(id);


            var mapper = new ActivityPageModel
            {
                ActivityId = result.ActivityId,
                MemberId = result.MemberId,
                ActivityLocation = result.ActivityLocation.Trim(),
                CategoryId = result.CategoryId,
                CategoryTypeId = result.CategoryTypeId,
                ActivityName = result.ActivityName.Trim(),
                StartDate = _commonService.ConvertTime(result.StartTime).First().DateConvert,
                StartTime = _commonService.ConvertTime(result.StartTime).First().TimeConvert,
                JoinDeadLine = _commonService.ConvertTime(result.JoinDeadLine).First().DateConvert,
                ActivityNotes = result.ActivityNotes.Trim(),
                CurrentPeople = result.CurrentPeople,
                MaxPeople = result.MaxPeople,
                ActivityImages = result.ActivityImages.Select(ai => new ActivityImageModel
                {
                    ActivityImageId = ai.ActivityImageId,
                    AiActivity = ai.AiActivity,
                    ImageName = ai.ImageName,
                    IsCover = ai.IsCover,
                    UploadTime = ai.UploadTime,
                })
            };

            return mapper;
        }

        /// <summary>
        /// 會員留言板查詢
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<MemberMsgModel> GetMemberMsg(int id)
        {
            return _activityRepository.GetMsgList(id).Select(r => new MemberMsgModel
            {
                MemberId = r.MemberId,
                ActivityId = r.ActivityId,
                HeadShot = r.HeadShot,
                MessageDate = _commonService.ConvertTime(r.MessageTime).First().DateConvert,
                MessageTime = _commonService.ConvertTime(r.MessageTime).First().TimeConvert,
                MessageText = r.MessageText,
                NickName = r.NickName,
            }).ToList();
        }

        /// <summary>
        /// 會員留言板新增
        /// </summary>
        /// <param name="memberMsgModel"></param>
        /// <returns></returns>
        public bool CreateMsg(MemberInsertMsgModel memberMsgModel)
        {
            var mapper = new MemberInsertMsgDto
            {
                MemberId = memberMsgModel.MemberId,
                ActivityId = memberMsgModel.ActivityId,
                MessageTime = memberMsgModel.MessageTime,
                MessageText = memberMsgModel.MessageText,
            };

            return (_activityRepository.InsertMsg(mapper)) ? true : false;
        }

        /// <summary>
        /// 回傳false代表活動頁面按鈕可以按
        /// </summary>
        /// <returns></returns>
        public JoinBtnCheckModel GetMemberStatus(int memberId, int activityId)
        {
            var result = _activityRepository.GetStatusById(memberId, activityId);
            return new JoinBtnCheckModel
            {
                Message = result.Message,
                BlnMemberStatus = result.BlnMemberStatus
            };
        }

        /// <summary>
        /// 活動申請
        /// </summary>
        /// <returns></returns>
        public bool CreateActivityUser(ActivityUserInsertModel activityUserInsertModel)
        {

            var mapper = new ActivityUserInsertDto
            {
                MemberId = activityUserInsertModel.MemberId,
                ActivityId = activityUserInsertModel.ActivityId,
                ReviewStatus = activityUserInsertModel.ReviewStatus,
                ReviewTime = activityUserInsertModel.ReviewTime,
            };

            if (!_activityRepository.InsertActivityUser(mapper))
            {
                return false;
            }

            return true;
        }
    }
}