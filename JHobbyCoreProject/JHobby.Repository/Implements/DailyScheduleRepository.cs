using JHobby.Repository.Enums;
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
    public class DailyScheduleRepository : IDailyScheduleRepository
    {
        private readonly JhobbyContext _jhobbyContext;

        public DailyScheduleRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext = jhobbyContext;
        }

        public void DailyCheck()
        {
            var expireActivities = _jhobbyContext.Activities.Include(z => z.ActivityUsers).Where(a => a.StartTime < DateTime.Now);

            foreach (var activity in expireActivities)
            {
                activity.ActivityStatus = Convert.ToString((int)ActiveStatusEnum.Over);

                var memberForScores = activity.ActivityUsers.Select(x => new Score
                {
                    ActivityId = activity.ActivityId,
                    MemberId = x.MemberId,
                    Fraction = null,
                    EvaluationTime = DateTime.Now,
                }).ToList();

                _jhobbyContext.Scores.AddRange(memberForScores);
            }
            _jhobbyContext.SaveChanges();
        }
    }
}