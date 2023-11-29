using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
	public class MemberDto
	{
		public int MemberId { get; set; }

		public string SaltPassword { get; set; } = null!;
		public string NewPassword { get; set; } = null!;
		public string HashPassword { get; set; } = null!;

	}
}
