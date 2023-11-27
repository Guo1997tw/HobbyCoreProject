using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JHobby.Service.Interfaces;

namespace JHobby.Service.Implements
{
    public class CommonService : ICommonService
    {
        /// <summary>
        /// 轉換ActivityStatus
        /// </summary>
        /// <param name="ActivityStatus"></param>
        /// <returns></returns>
        public string ConvertActivityStatus(string status)
        {
            return status switch
            {
                "0" => "黑名單",
                "1" => "進行中",
                "2" => "已完成",
                _ => "未知"
            };
        }

        /// <summary>
        /// 轉換ReviewStatus
        /// </summary>
        /// <param name="ReviewStatus"></param>
        /// <returns></returns>
        public string ConvertReviewStatus(string status) 
        {
            return status switch
            {
                "0" => "未通過",
                "1" => "通過",
                "2" => "待審核",
                _ => "未知"
            };
        }

        /// <summary>
        /// 計算剩餘人數
        /// </summary>
        /// <param name="MaxPeople"></param>
        /// <param name="CurrentPeople"></param>
        /// <returns></returns>
        public int CountSurplusQuota(int? max, int? current) 
        {
            return max.GetValueOrDefault() - current.GetValueOrDefault();
        }
    }
}
