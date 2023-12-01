namespace JHobby.Website.Models.ViewModels
{
    public class ActivityUserInsertViewModel
    {
        public int MemberId { get; set; }

        public int ActivityId { get; set; }

        public string ReviewStatus { get; set; } = null!;

        public DateTime ReviewTime { get; set; }
    }
}