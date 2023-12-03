using Hangfire;
using JHobby.Service.Interfaces;

namespace JHobby.Website.Job
{
    public class JhobbyScheduleJobWorker
    {
        private readonly IDailyScheduleService _dailyScheduleService;
        private readonly IBackgroundJobClient backgroundJobs;

        public JhobbyScheduleJobWorker(IDailyScheduleService dailyScheduleService, IBackgroundJobClient backgroundJobs)
        {
            _dailyScheduleService = dailyScheduleService;
            this.backgroundJobs = backgroundJobs;
        }
        public void ExecuteAllJob()
        {
            //backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
            RecurringJob.AddOrUpdate("ActiveityStatusCheckJob", () => _dailyScheduleService.ActivityEndCheck(), "*/10 * * * *");
        }
    }
}