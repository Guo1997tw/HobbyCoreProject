namespace JHobby.Website.Models.ViewModels
{
    public class MemberMsgViewModel
    {
        public int MemberId { get; set; }
        public string? HeadShot { get; set; }

        public string? MessageDate { get; set; }

        public string? MessageTime { get; set; }

        public string? NickName { get; set; }

        public string MessageText { get; set; } = null!;
    }
}