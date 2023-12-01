namespace JHobby.Website.Models.ViewModels
{
    public class MemberStatusViewModel
    {
        public int MemberId { get; set; }

        public string Account { get; set; } = null!;

        public string Status { get; set; } = null!;
    }
}