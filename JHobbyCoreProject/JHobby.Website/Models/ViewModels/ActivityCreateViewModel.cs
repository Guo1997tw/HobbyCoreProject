namespace JHobby.Website.Models.ViewModels
{
    public class ActivityCreateViewModel
    {
        public int ActivityId { get; set; }

        public int MemberId { get; set; }

        public string ActivityStatus { get; set; } = "1";

        public string Payment { get; set; } = null!;

        public string ActivityName { get; set; } = null!;

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

        public DateTime Created { get; set; }

        public List<IFormFile> File { get; set; }
    }
}