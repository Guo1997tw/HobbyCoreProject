using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JHobby.Repository.Implements
{
    public class NowJoinAGroupRepository : INowJoinAGroupRepository
    {
        private readonly JhobbyContext _jhobbyContext;

        public NowJoinAGroupRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext = jhobbyContext;
        }

        public IEnumerable<NowJoinAGroupDto> GetNowJoinAGroupAll()
        {
            var nowDto = _jhobbyContext.ActivityUsers
                .Include(Au => Au.Activity)
                .Include(Au => Au.Member)
                .Select(a => new NowJoinAGroupDto
                {
                    ActivityId = a.ActivityId,
                    ActivityName = a.Activity.ActivityName,
                    ActivityUserId = a.ActivityUserId,
                    ReviewStatus = a.ReviewStatus,
                    ReviewTime = a.ReviewTime,
                    CurrentPeople = a.Activity.CurrentPeople,
                    MaxPeople = a.Activity.MaxPeople,
                    NickName = a.Member.NickName,
                    StartTime = a.Activity.StartTime,
                });
            return nowDto;
        }

        public PageFilterDto<NowJoinAGroupDto> GetNowJoinAGroupById(int memberId, int pageNumber, int countPerPage)
        {
            var activityUser = _jhobbyContext.Members.Select(x => new { id = x.MemberId, nickName = x.NickName });
            var activityImage = _jhobbyContext.ActivityImages.Select(a => new { id = a.ActivityId, imageName = a.ImageName });

            if (_jhobbyContext.Activities.All(ad => ad.ActivityStatus == "1"))
            {
                var query = _jhobbyContext.ActivityUsers
                .Where(Au => Au.MemberId == memberId
                && (Au.ReviewStatus == "0"
                || Au.ReviewStatus == "1"
                || Au.ReviewStatus == "2"
                || Au.ReviewStatus == "4"))
                .Include(Au => Au.Activity)
                .Select(a => new NowJoinAGroupDto
                {
                    ActivityName = a.Activity.ActivityName,
                    ActivityUserId = a.ActivityUserId,
                    ActivityId = a.ActivityId,
                    MemberId = a.MemberId,
                    ReviewStatus = a.ReviewStatus,
                    CurrentPeople = a.Activity.CurrentPeople,
                    MaxPeople = a.Activity.MaxPeople,
                    NickName = activityUser.FirstOrDefault(z => z.id == a.Activity.MemberId).nickName,
                    StartTime = a.Activity.StartTime,
                    ImageName = activityImage.FirstOrDefault(i => i.id == a.Activity.ActivityId).imageName
                });

                var totalItems = query.Count();
                var totalPage = (int)Math.Ceiling(totalItems / (decimal)countPerPage);
                var filterPage = query
                    .Skip((pageNumber - 1) * countPerPage)
                    .Take(countPerPage);

                return new PageFilterDto<NowJoinAGroupDto>
                {
                    PageNumber = pageNumber,
                    TotalPages = totalPage,
                    Items = filterPage
                };
            }
            else
            {
                return null;
            }

        }

        public bool NowJoinAGroupCancel(int activityId, int memberId, NowJoinAGroupCancelDto aGroupCancelDto)
        {
            List<ActivityUser> cancelUsers = _jhobbyContext.ActivityUsers.
                Where(Au => Au.ActivityId == activityId).ToList();

            var activityCurrentPeople = _jhobbyContext.Activities.
                FirstOrDefault(a => a.ActivityId == activityId);

            if (activityCurrentPeople != null)
            {
                foreach (var activityUser in cancelUsers)
                {
                    if (activityUser.MemberId == memberId)
                    {
                        activityUser.ReviewStatus = aGroupCancelDto.ReviewStatus;
                    }
                }
                activityCurrentPeople.CurrentPeople = cancelUsers.Where(Cu => Cu.ReviewStatus == "1").Count();
                _jhobbyContext.SaveChanges();
                return true;
            }
            else { return false; }
        } 
    }
}
