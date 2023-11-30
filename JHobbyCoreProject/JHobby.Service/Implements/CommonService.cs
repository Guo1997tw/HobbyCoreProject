using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JHobby.Service.Interfaces;
using JHobby.Service.Models.Dto;

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

        /// <summary>
        /// 將Sql Sever內的時間轉成日期格式和時間格式
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public IEnumerable<TimeModelDto> ConvertTime(DateTime dateTime)
        {
            string dateConvert = dateTime.ToString("yyyy-MM-dd");
            string timeConvert = dateTime.ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);

            TimeModelDto timeModelDto = new TimeModelDto
            {
                DateConvert = dateConvert,
                TimeConvert = timeConvert,
            };

            yield return timeModelDto;
        }
        /// <summary>
        /// 取字串檢查
        /// </summary>
        /// <param name="shotCheck"></param>
        /// <returns></returns>
        public int ShotCheck(int len, string str)
        {
            if (len >= str.Length)
            {
                len = str.Length;
            }
            return len;
        }
    }
}
