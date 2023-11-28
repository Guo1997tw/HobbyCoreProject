namespace JHobby.Website.Models.ViewModels
{
	public class GroupStartingViewModel
	{
		public int ActivityId { get; set; }
		public string ActivityName { get; set; } = null!;
		public int? CurrentPeople { get; set; }
		public int MemberId { get; set; }
		public DateTime StartTime { get; set; }
		public int? MaxPeople { get; set; }
		public string ActivityStatus { get; set; } = null!;
		public bool IsCover { get; set; }
		public string ImageName { get; set; } = null!;
		public int ActivityImageId { get; set; }
	}
}
