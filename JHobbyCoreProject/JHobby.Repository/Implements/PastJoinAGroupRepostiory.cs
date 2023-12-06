using Azure;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JHobby.Repository.Implements
{
    public class PastJoinAGroupRepostiory : IPastJoinAGroupRepostiory
    {
        private readonly JhobbyContext _JhobbyContext;

        public PastJoinAGroupRepostiory(JhobbyContext jhobbyContext)
        {

            _JhobbyContext = jhobbyContext;
        }

        public IEnumerable<PastJoinAGroupDto> GetPastJoinAGroupAll()
        {
            return _JhobbyContext.Activities.Join(
               _JhobbyContext.Members,
               a => a.MemberId,
               m => m.MemberId,
               (a, m) => new PastJoinAGroupDto
               {
                   ActivityId = a.ActivityId,
                   ActivityName = a.ActivityName,
                   ActivityStatus = a.ActivityStatus,
                   ActivityCity = a.ActivityCity,
                   CurrentPeople = a.CurrentPeople,
                   StartTime = a.StartTime,
                   NickName = m.NickName
               });
        }

        public IEnumerable<PastJoinAGroupDto> GetPastJoinAGroupById(int memberId)
        {
            var activityUsers = _JhobbyContext.Members.Select(m => new { id = m.MemberId, nikeName = m.NickName });
            var scoreByMemberId = _JhobbyContext.Scores.Select(s => new { id = s.MemberId, score = s.Fraction, activityid = s.ActivityId });
            var imageName = _JhobbyContext.ActivityImages.Select(ai => new { id = ai.ActivityId, imageName = ai.ImageName });

            return _JhobbyContext.ActivityUsers
                .Where(Au => Au.MemberId == memberId)
                .Include(Au => Au.Activity)
                .Include(Au => Au.Member)
                .Select(a => new PastJoinAGroupDto
                {
                    ActivityId = a.ActivityId,
                    ActivityName = a.Activity.ActivityName,
                    ActivityStatus = a.Activity.ActivityStatus,
                    ActivityCity = a.Activity.ActivityCity,
                    CurrentPeople = a.Activity.CurrentPeople,
                    StartTime = a.Activity.StartTime,
                    NickName = activityUsers
                    .FirstOrDefault(ac => ac.id == a.Activity.MemberId)
                    .nikeName,
                    MemberId = a.Activity.MemberId,
                    Fraction = scoreByMemberId
                    .FirstOrDefault(s => s.id == a.Activity.MemberId
                    && s.activityid == a.ActivityId)
                    .score,
                    ImageName = imageName.FirstOrDefault(i => i.id == a.Activity.ActivityId).imageName,
                });
        }

    }

}
