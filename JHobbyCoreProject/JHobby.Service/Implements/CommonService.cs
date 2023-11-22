﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class CommonService : ICommonService
    {
        /// <summary>
        /// 轉換ActivityStatus
        /// </summary>
        /// <param name="ConvertActivityStatus"></param>
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
    }
}
