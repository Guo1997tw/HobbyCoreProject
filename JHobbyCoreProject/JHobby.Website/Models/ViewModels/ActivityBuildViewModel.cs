namespace JHobby.Website.Models.ViewModels
{
	public class ActivityBuildViewModel
	{
		public string ActivityCity { get; set; } = null!;
		public string ActivityArea { get; set; } = null!;
		public string ActivityLocation { get; set; } = null!;
		public DateTime StartTime { get; set; }
		public int? MaxPeople { get; set; }
		public int CategoryId { get; set; }
		public int CategoryTypeId { get; set; }
		public DateTime JoinDeadLine { get; set; }
		public decimal JoinFee { get; set; }
		public string? ActivityNotes { get; set; }
		public int ActivityId { get; set; }					

	}
}
