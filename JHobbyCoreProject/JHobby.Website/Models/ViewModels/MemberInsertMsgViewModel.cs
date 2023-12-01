namespace JHobby.Website.Models.ViewModels
{
    public class MemberInsertMsgViewModel
    {
        public int MemberId { get; set; }

        public int ActivityId { get; set; }

        public DateTime MessageTime { get; set; }

        public string MessageText { get; set; } = null!;
    }
}