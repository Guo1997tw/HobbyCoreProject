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
    }
}
