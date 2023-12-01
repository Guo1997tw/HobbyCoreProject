namespace JHobby.Website.Models.ViewModels
{
	public class MemberViewModel
	{
		public int MemberId { get; set; }
		public string SaltPassword { get; set; } = null!;
		public string NewPassword { get; set; } = null!;
		public string HashPassword { get; set; } = null!;
	}
}
