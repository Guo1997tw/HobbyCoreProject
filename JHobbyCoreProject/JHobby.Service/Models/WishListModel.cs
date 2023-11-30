﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class WishListModel
    {
        public int WishId { get; set; }

        public int MemberId { get; set; }

        public int ActivityId { get; set; }

        public DateTime AddTime { get; set; }

        //活動狀態
        public string ActivityStatus { get; set; } = null!;

        public string ActivityName { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime JoinDeadLine { get; set; }

        public string? NickName { get; set; }

        public int SurplusQuota { get; set; }

    }
}
