using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Enums
{
    public enum ActiveStatusEnum
    {
        Blacklist = 0,
        InProgress = 1,

        /// <summary>
        /// 已結束
        /// </summary>
        Over = 2,
    }
}