using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class PastJoinAGroupDto
    {
        public int ActivityId { get; set; }

        public string ActivityName { get; set; } = null!;

        public string ActivityStatus { get; set; } = null!;

        public string ActivityCity { get; set; } = null!;

        public int? CurrentPeople { get; set; }

        public DateTime StartTime { get; set; }

        public string? NickName { get; set; }

    }
}
