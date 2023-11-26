using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
	public class ActivityPageDto
	{
		public int ActivityId { get; set; }

        public int CategoryId { get; set; }

        public int CategoryTypeId { get; set; }

        public string ActivityName { get; set; } = null!;

        public string ActivityLocation { get; set; } = null!;

		public DateTime StartTime { get; set; }

		public DateTime JoinDeadLine { get; set; }

		public string? ActivityNotes { get; set; }
	}
}