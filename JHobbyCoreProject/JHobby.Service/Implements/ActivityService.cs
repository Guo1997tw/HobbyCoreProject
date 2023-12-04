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

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
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
                ActivityLocation = result.ActivityLocation,
                CategoryId = result.CategoryId,
                CategoryTypeId = result.CategoryTypeId,
                ActivityName = result.ActivityName,
                StartTime = result.StartTime,
                JoinDeadLine = result.JoinDeadLine,
                ActivityNotes = result.ActivityNotes,
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
                ActivityId = r.ActivityId,
                HeadShot = r.HeadShot,
                MessageTime = r.MessageTime,
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
        /// 查詢會員活動申請者是否已參團或本身是開團者
        /// </summary>
        /// <returns></returns>
        public bool GetMemberStatus(int memberId, int activityId)
        {
            return _activityRepository.GetStatusById(memberId, activityId);
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