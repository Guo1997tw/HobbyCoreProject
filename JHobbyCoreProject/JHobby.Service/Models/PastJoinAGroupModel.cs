using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class PastJoinAGroupModel
    {
        public int ActivityId { get; set; }

        public int MemberId { get; set; }

        public string ActivityName { get; set; } = null!;

        public string ActivityStatus { get; set; } = null!;

        public string ActivityCity { get; set; } = null!;

        public int? CurrentPeople { get; set; }

        public DateTime StartTime { get; set; }

        public string? NickName { get; set; }

        public string? DateConvert { get; set;}

        public string? TimeConvert { get; set; }
    }
}
