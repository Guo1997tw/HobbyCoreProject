namespace JHobby.Website.Models.ViewModels
{
    public class MemberRegisterViewModel
    {
        public string Account { get; set; } = null!;

        public string HashPassword { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime CreationDate { get; set; }
    }
}