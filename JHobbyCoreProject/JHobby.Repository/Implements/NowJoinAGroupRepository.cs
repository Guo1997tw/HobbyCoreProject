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

        //public IEnumerable<NowJoinAGroupDto> GetNowJoinAGroupById(int memberId)
        //{
        //    return _jhobbyContext.ActivityUsers
        //        .Where(Au => Au.MemberId == memberId)
        //        .Include(Au => Au.Activity)
        //        .Include(Au => Au.Member)
        //        .Select(a => new NowJoinAGroupDto
        //        {
        //            ActivityId = a.ActivityId,
        //            ActivityName = a.Activity.ActivityName,
        //            ActivityUserId = a.ActivityUserId,
        //            ReviewStatus = a.ReviewStatus,
        //            ReviewTime = a.ReviewTime,
        //            CurrentPeople = a.Activity.CurrentPeople,
        //            MaxPeople = a.Activity.MaxPeople,
        //            NickName = a.Member.NickName,
        //            StartTime = a.Activity.StartTime,
        //        });
        //}

        public IEnumerable<NowJoinAGroupDto> GetNowJoinAGroupById(int memberId)
        {
            return _jhobbyContext.ActivityUsers
                .Where(Au => Au.MemberId == memberId)
                .Join(_jhobbyContext.Activities,
                Au => Au.ActivityId,
                Ac => Ac.ActivityId, (Au, Ac) => new
                {
                    ActivityId = Au.ActivityId,
                    ActivityName = Ac.ActivityName,
                    ActivityUserId = Au.ActivityUserId,
                    ReviewStatus = Au.ReviewStatus,
                    ReviewTime = Au.ReviewTime,
                    CurrentPeople = Au.Activity.CurrentPeople,
                    MaxPeople = Au.Activity.MaxPeople,
                    StartTime = Au.Activity.StartTime,
                    JoinAGroupPersonId = memberId,
                    MemberId = Au.MemberId,
                })
                .Join(_jhobbyContext.Members,
                AuAc => AuAc.MemberId,
                M => M.MemberId, (AuAc, M) => new NowJoinAGroupDto
                {
                    ActivityId = AuAc.ActivityId,
                    ActivityName = AuAc.ActivityName,
                    ActivityUserId = AuAc.ActivityUserId,
                    ReviewStatus = AuAc.ReviewStatus,
                    ReviewTime = AuAc.ReviewTime,
                    CurrentPeople = AuAc.CurrentPeople,
                    MaxPeople = AuAc.MaxPeople,
                    NickName = M.NickName,
                    StartTime =AuAc.StartTime,
                    JoinAGroupPersonId = AuAc.JoinAGroupPersonId,
                    LunchAGroupPersonId = M.MemberId
                });
        }


    }
}
