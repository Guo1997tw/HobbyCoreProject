using Hangfire;
using JHobby.Repository.Implements;
using JHobby.Repository.Interfaces;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;

namespace JHobby.Website.Job
{
    public static class JhobbyScheduleJobExtenstion
    {
        public static IServiceCollection AddJhobbyScheduleJob(this IServiceCollection services)
        { 
            services.AddScoped<IDailyScheduleService, DailyScheduleService>();
            services.AddScoped<IDailyScheduleRepository, DailyScheduleRepository>();
            services.AddScoped<JhobbyScheduleJobWorker, JhobbyScheduleJobWorker>();
            return services;
        }

        public static WebApplication UseJhobbyDailyJob(this WebApplication app)
        {
            using (var sc = app.Services.CreateScope())
            {
                var worker = sc.ServiceProvider.GetRequiredService<JhobbyScheduleJobWorker>();
                worker.ExecuteAllJob();
                return app;
                
            }
        }
        

    }
}
