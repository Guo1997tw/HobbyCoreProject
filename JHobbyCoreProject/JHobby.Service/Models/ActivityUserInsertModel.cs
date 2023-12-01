namespace JHobby.Service.Models
{
    public class ActivityUserInsertModel
    {
        public int MemberId { get; set; }

        public int ActivityId { get; set; }

        public string ReviewStatus { get; set; } = null!;

        public DateTime ReviewTime { get; set; }
    }
}