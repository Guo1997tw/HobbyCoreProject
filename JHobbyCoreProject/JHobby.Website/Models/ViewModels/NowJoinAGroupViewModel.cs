namespace JHobby.Website.Models.ViewModels
{
    public class NowJoinAGroupViewModel
    {
        public string ActivityName { get; set; } = null!;

        public string ActivityStatus { get; set; } = null!;

        public string ActivityCity { get; set; } = null!;

        public int? CurrentPeople { get; set; }

        public int? MaxPeople { get; set; }

        public DateTime StartTime { get; set; }

        public string? NickName { get; set; }
    }
}
