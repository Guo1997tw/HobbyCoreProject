using JHobby.Repository.Models.Entity;

namespace JHobby.Website.Models.ViewModels
{
    public class NowJoinAGroupViewModel
    {

        public string ActivityName { get; set; } = null!;

        public string ReviewStatus { get; set; } = null!;

        public DateTime ReviewTime { get; set; }

        public int? CurrentPeople { get; set; }

        public int? MaxPeople { get; set; }

        //團主NickName
        public string? NickName { get; set; }

        public DateTime StartTime { get; set; }

        public virtual Activity Activity { get; set; } = null!;

        public virtual Member Member { get; set; } = null!;

        public string? DateConvert { get; set; }

        public string? TimeConvert { get; set; }
    }
}
