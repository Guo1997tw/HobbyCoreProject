using JHobby.Repository.Interfaces;
using JHobby.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class DailyScheduleService : IDailyScheduleService
    {
        private readonly IDailyScheduleRepository _dailyScheduleRepository;

        public DailyScheduleService(IDailyScheduleRepository dailyScheduleRepository)
        {
            _dailyScheduleRepository = dailyScheduleRepository;
        }

        /// <summary>
        /// 活動結束確認Job
        /// </summary>
        public void ActivityEndCheck()
        {
            _dailyScheduleRepository.DailyCheck();
        }
    }
}