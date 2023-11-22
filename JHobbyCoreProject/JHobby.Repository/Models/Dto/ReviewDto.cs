using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
	internal class ReviewDto
	{
		public int ActivityId { get; set; }

		public int MemberId { get; set; }
		public string ActivityName { get; set; } = null!;

	}
}
