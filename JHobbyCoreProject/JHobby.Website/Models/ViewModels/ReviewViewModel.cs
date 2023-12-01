namespace JHobby.Website.Models.ViewModels
{
	public class ReviewViewModel
	{
		public int ActivityId { get; set; }
		public int LeaderId { get; set; }  //團主Id
		public string ReviewStatus { get; set; } = null!;
		public string ReviewTime { get; set; }
		public string ActivityName { get; set; } = null!;
		public int ActivityImageId { get; set; }
		public string ImageName { get; set; } = null!;
		public bool IsCover { get; set; }
		public int ApplicantId { get; set; } //申請者Id
		public string? NickName { get; set; }
		public string? HeadShot { get; set; }
	}
}
