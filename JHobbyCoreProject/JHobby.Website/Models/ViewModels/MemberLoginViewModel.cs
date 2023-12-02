namespace JHobby.Website.Models.ViewModels
{
    public class MemberLoginViewModel
    {
        public int MemberId { get; set; }

        public string Account { get; set; } = null!;

        public string HashPassword { get; set; } = null!;
    }
}