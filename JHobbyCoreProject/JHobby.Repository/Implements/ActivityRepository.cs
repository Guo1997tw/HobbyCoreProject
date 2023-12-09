using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JHobby.Repository.Implements
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly JhobbyContext _jhobbyContext;
        private readonly IMapper _mapper;

        public ActivityRepository(JhobbyContext jhobbyContext, IMapper mapper)
        {
            _jhobbyContext = jhobbyContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 團主建立
        /// </summary>
        /// <param name="activityCreateDto"></param>
        /// <returns></returns>
        public bool ActivityBuild(ActivityCreateDto activityCreateDto)
        {
            try
            {
                _jhobbyContext.Activities.Add(_mapper.Map<Activity>(activityCreateDto));

                _jhobbyContext.SaveChanges();

                return true;
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// 會員留言板查詢
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MemberMsgDto> GetMsgList(int id)
        {
            var result = _jhobbyContext.Members.Join(_jhobbyContext.MsgBoards, m => m.MemberId, mb => mb.MemberId, (m, mb) => new MemberMsgDto
            {
                MemberId = mb.MemberId,
                ActivityId = mb.ActivityId,
                HeadShot = m.HeadShot,
                MessageTime = mb.MessageTime,
                MessageText = mb.MessageText,
                NickName = m.NickName
            }).Where(f => f.ActivityId == id).ToList();

            return result;
        }

        /// <summary>
        /// 團主修改
        /// </summary>
        /// <param name="activityUpdateDto"></param>
        /// <returns></returns>
        public bool ActivityUpdate(int id, ActivityUpdateDto activityUpdateDto)
        {
            var query = _jhobbyContext.Activities.FirstOrDefault(a => a.ActivityId == id);

            if (query == null) return false;

            try
            {
                _mapper.Map(activityUpdateDto, query);
                _jhobbyContext.SaveChanges();
            }
            catch (Exception) { return false; }

            return true;
        }

        /// <summary>
        /// 取得開團資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ActivityStatusDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ActivityStatusDto ActivityStatus(int id)
        {
            var queryResult = _jhobbyContext.Activities.FirstOrDefault(a => a.ActivityId == id);

            if (queryResult == null) { return null; }

            return _mapper.Map<ActivityStatusDto>(queryResult);
        }

        /// <summary>
        /// 活動頁面查詢
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ActivityPageDto GetActivityPageById(int id)
        {
            var queryResult = _jhobbyContext.Activities
                .Include(a => a.ActivityImages)
                .Where(a => a.ActivityId == id)
                .Select(a => new ActivityPageDto
                {
                    ActivityId = a.ActivityId,
                    MemberId = a.MemberId,
                    ActivityLocation = a.ActivityLocation,
                    CategoryId = a.CategoryId,
                    CategoryTypeId = a.CategoryTypeId,
                    ActivityName = a.ActivityName,
                    StartTime = a.StartTime,
                    JoinDeadLine = a.JoinDeadLine,
                    ActivityNotes = a.ActivityNotes,
                    CurrentPeople = a.CurrentPeople,
                    MaxPeople = a.MaxPeople,
                    ActivityImages = a.ActivityImages.Select(ai => new ActivityImageDto
                    {
                        ActivityImageId = ai.ActivityImageId,
                        AiActivity = ai.ActivityImageId,
                        ImageName = ai.ImageName,
                        IsCover = ai.IsCover,
                        UploadTime = ai.UploadTime,
                    }).ToList()
                }).FirstOrDefault();

            return queryResult;
        }

        /// <summary>
        /// 會員留言板新增
        /// </summary>
        /// <param name="id"></param>
        /// <param name="memberInsertMsgDto"></param>
        /// <returns></returns>
        public bool InsertMsg(MemberInsertMsgDto memberInsertMsgDto)
        {
            var mapper = new MsgBoard
            {
                MemberId = memberInsertMsgDto.MemberId,
                ActivityId = memberInsertMsgDto.ActivityId,
                MessageTime = memberInsertMsgDto.MessageTime,
                MessageText = memberInsertMsgDto.MessageText,
            };

            _jhobbyContext.MsgBoards.Add(mapper);
            _jhobbyContext.SaveChanges();

            return true;
        }

        /// <summary>
        /// 回傳false代表活動頁面按鈕可以按
        /// </summary>
        /// <returns></returns>
        public JoinBtnCheckDto GetStatusById(int memberId, int activityId)
        {
            JoinBtnCheckDto JoinBtnCheck = new JoinBtnCheckDto
            {
                Message = "參加",
                BlnMemberStatus = false
            };
            if (_jhobbyContext.Activities.Any(a => (a.ActivityId == activityId &&
                                                   a.JoinDeadLine < DateTime.Now.AddDays(-1)) ||
                                                   (a.ActivityId == activityId &&
                                                   a.ActivityStatus != "1")))
            {
                JoinBtnCheck.Message = "活動已結束";
                JoinBtnCheck.BlnMemberStatus = true;
                return JoinBtnCheck;
            }
            if (_jhobbyContext.Activities.Any(a => a.MemberId == memberId && a.ActivityId == activityId))
            {
                JoinBtnCheck.Message = "團主不可再次參加";
                JoinBtnCheck.BlnMemberStatus = true;
                return JoinBtnCheck;
            }
            if (_jhobbyContext.ActivityUsers.Any(a => a.MemberId == memberId && a.ActivityId == activityId))
            {
                JoinBtnCheck.Message = "您已參加";
                JoinBtnCheck.BlnMemberStatus = true;
                return JoinBtnCheck;
            }
            var CurrentPeople = _jhobbyContext.Activities.FirstOrDefault(a => a.ActivityId == activityId).CurrentPeople;
            var maxPeople = _jhobbyContext.Activities.FirstOrDefault(a => a.ActivityId == activityId).MaxPeople;
            if (CurrentPeople >= maxPeople)
            {
                JoinBtnCheck.Message = "參加人數已滿";
                JoinBtnCheck.BlnMemberStatus = true;
                return JoinBtnCheck;
            }
            return JoinBtnCheck;
        }

        /// <summary>
        /// 活動申請
        /// </summary>
        /// <returns></returns>
        public bool InsertActivityUser(ActivityUserInsertDto activityUserInsert)
        {
            if (_jhobbyContext.ActivityUsers.Any(a => a.ActivityId == activityUserInsert.ActivityId && a.MemberId == activityUserInsert.MemberId))
            {
                return false;
            }
            try
            {
                var mapper = new ActivityUser
                {
                    MemberId = activityUserInsert.MemberId,
                    ActivityId = activityUserInsert.ActivityId,
                    ReviewStatus = activityUserInsert.ReviewStatus,
                    ReviewTime = activityUserInsert.ReviewTime,
                };
                _jhobbyContext.ActivityUsers.Add(mapper);
                _jhobbyContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}