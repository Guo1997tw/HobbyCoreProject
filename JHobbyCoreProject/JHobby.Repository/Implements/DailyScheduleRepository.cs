using JHobby.Repository.Enums;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;

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
            var expireActivities = _jhobbyContext.Activities.
                Include(z => z.ActivityUsers).
                Where(a => a.StartTime < DateTime.Now && a.ActivityStatus != Convert.ToString((int)ActiveStatusEnum.Over));

            foreach (var activity in expireActivities)
            {
                activity.ActivityStatus = Convert.ToString((int)ActiveStatusEnum.Over);

                var memberForScores = activity.ActivityUsers.
                    Where(x => x.ReviewStatus == "1").
                    Select(x => new Score
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