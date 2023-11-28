using JHobby.Repository.Models.Entity;

namespace JHobby.Website.Models.ViewModels
{
	public class ActivityPageViewModel
	{
		public int ActivityId { get; set; }

        public int CategoryId { get; set; }

        public int CategoryTypeId { get; set; }

        public string ActivityName { get; set; } = null!;

		public string ActivityLocation { get; set; } = null!;

		public DateTime StartTime { get; set; }

		public DateTime JoinDeadLine { get; set; }

		public string? ActivityNotes { get; set; }

        public virtual IEnumerable<ActivityImageViewModel> ActivityImages { get; set; } = new List<ActivityImageViewModel>();
    }
}