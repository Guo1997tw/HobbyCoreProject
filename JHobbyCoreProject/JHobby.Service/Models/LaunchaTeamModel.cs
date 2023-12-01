using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class LaunchaTeamModel
    {
        public int MemberId { get; set; }
        public string ActivityName { get; set; } = null!;
        public string ActivityStatus { get; set; } = null!;
        public int? CurrentPeople { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsCover { get; set; }
        public string ImageName { get; set; } = null!;

		public DateTime Created { get; set; }
		public int ActivityImageId { get; set; }
    }
}
