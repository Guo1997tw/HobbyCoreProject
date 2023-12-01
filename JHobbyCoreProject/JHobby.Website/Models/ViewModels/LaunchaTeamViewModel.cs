namespace JHobby.Website.Models.ViewModels
{
    public class LaunchaTeamViewModel
    {
        public int MemberId { get; set; }
        public string ActivityName { get; set; } = null!;
        public string ActivityStatus { get; set; } = null!;
        public DateTime StartTime { get; set; }

        public int? CurrentPeople { get; set; }
        public bool IsCover { get; set; }
        public string ImageName { get; set; } = null!;

		public DateTime Created { get; set; }
		public int ActivityImageId { get; set; }
    }
}
