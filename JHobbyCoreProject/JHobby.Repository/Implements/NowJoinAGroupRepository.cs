using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<NowJoinAGroupDto> GetNowJoinAGroupById(int memberId)
        {
            var activityUser = _jhobbyContext.Members.Select(x => new { id = x.MemberId, nickName = x.NickName });
            
            return _jhobbyContext.ActivityUsers
            .Where(Au => Au.MemberId == memberId
            && (Au.ReviewStatus == "0"
            || Au.ReviewStatus == "1"
            || Au.ReviewStatus == "2"
            || Au.ReviewStatus == "4"))
            .Include(Au => Au.Activity)
            .Select(a => new NowJoinAGroupDto
            {
                ActivityName = a.Activity.ActivityName,
                ActivityUserId= a.ActivityUserId,
                MemberId = a.MemberId,
                ReviewStatus = a.ReviewStatus,
                CurrentPeople = a.Activity.CurrentPeople,
                MaxPeople = a.Activity.MaxPeople,
                NickName = activityUser.FirstOrDefault(z => z.id == a.Activity.MemberId).nickName,
                StartTime = a.Activity.StartTime,
            });
        }

        public bool NowJoinAGroupCancel(int activityUserId, int memberId, NowJoinAGroupCancelDto aGroupCancelDto)
        {
            var cancelDto = _jhobbyContext.ActivityUsers
                .FirstOrDefault(Au =>
                Au.MemberId == memberId
                && Au.ActivityUserId == activityUserId);

            if (cancelDto != null)
            {
                cancelDto.ReviewStatus = aGroupCancelDto.ReviewStatus;
                _jhobbyContext.SaveChanges();
                return true;
            }
            else { return false; }
           

        }
    }
}
