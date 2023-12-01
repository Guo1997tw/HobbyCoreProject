namespace JHobby.Repository.Models.Dto
{
    public class ActivityUserInsertDto
    {
        public int MemberId { get; set; }

        public int ActivityId { get; set; }

        public string ReviewStatus { get; set; } = null!;

        public DateTime ReviewTime { get; set; }
    }
}