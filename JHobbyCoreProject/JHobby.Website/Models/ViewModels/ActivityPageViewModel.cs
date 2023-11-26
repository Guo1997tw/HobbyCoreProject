namespace JHobby.Website.Models.ViewModels
{
	public class ActivityPageViewModel
	{
		public int ActivityId { get; set; }

		public string ActivityName { get; set; } = null!;

		public string ActivityLocation { get; set; } = null!;

		public DateTime StartTime { get; set; }

		public DateTime JoinDeadLine { get; set; }

		public string? ActivityNotes { get; set; }
	}
}