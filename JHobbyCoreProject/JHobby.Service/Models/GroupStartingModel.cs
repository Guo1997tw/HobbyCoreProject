﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class GroupStartingModel
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; } = null!;
        public int? CurrentPeople { get; set; }

        public string ReviewStatus { get; set; } = null!;
        public int MemberId { get; set; }
       
        public DateTime StartTime { get; set; }
        public int? MaxPeople { get; set; }
        public string ActivityStatus { get; set; } = null!;
        public bool IsCover { get; set; }
        public string ImageName { get; set; } = null!;
        public int ActivityImageId { get; set; }
        public string? DateConvert { get; set; }

        public string? TimeConvert { get; set; }
    }
}
