using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class NowJoinAGroupDto
    {
        public int ActivityUserId { get; set; }

        public int ActivityId { get; set; }

        //參團者ID
        public int MemberId { get; set; }

        public string ActivityName { get; set; } = null!;

        public string ReviewStatus { get; set; } = null!;

        public DateTime ReviewTime { get; set; }

        public int? CurrentPeople { get; set; }

        public int? MaxPeople { get; set; }

        //團主NickName
        public string? NickName { get; set; }

        public DateTime StartTime { get; set; }

        public virtual Activity Activity { get; set; } = null!;

        public virtual Member Member { get; set; } = null!;
    }
}
