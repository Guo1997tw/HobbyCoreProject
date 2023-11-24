namespace JHobby.Website.Models.ViewModels
{
	public class ProfileSettingViewModel
	{
		public string? HeadShot { get; set; }

		public string Status { get; set; } = null!;

		public int MemberId { get; set; }

		public string? MemberName { get; set; }

		public string? NickName { get; set; }

		public string? Gender { get; set; }

		public string? IdentityCard { get; set; }

		public DateTime? Birthday { get; set; }

		public string? AcitveCity { get; set; }

		public string? ActiveArea { get; set; }

		public string? Address { get; set; }

		public string? Phone { get; set; }
		public string? PersonalProfile { get; set; }
	}
}
