using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
	public class ActivityPageModel
	{
		public int ActivityId { get; set; }

        public int MemberId { get; set; }

        public int CategoryId { get; set; }

        public int CategoryTypeId { get; set; }

        public string ActivityName { get; set; } = null!;

		public string ActivityLocation { get; set; } = null!;

        public string? StartDate { get; set; }

        public string? StartTime { get; set; }

        public string? JoinDeadLine { get; set; }

		public string? ActivityNotes { get; set; }

        public virtual IEnumerable<ActivityImageModel> ActivityImages { get; set; } = new List<ActivityImageModel>();
    }
}