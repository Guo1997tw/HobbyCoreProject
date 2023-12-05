namespace JHobby.Website.Models.ViewModels
{
    public class PastJoinAGroupViewModel
    {
        public int ActivityId { get; set; }

        public string ActivityName { get; set; } = null!;

        public string ActivityStatus { get; set; } = null!;

        public string ActivityCity { get; set; } = null!;

        public int? CurrentPeople { get; set; }

        public int MemberId { get; set; }

        public string? NickName { get; set; }

        public string? DateConvert { get; set; }

        public string? TimeConvert { get; set; }

        public int? Fraction { get; set; }
    }
}
