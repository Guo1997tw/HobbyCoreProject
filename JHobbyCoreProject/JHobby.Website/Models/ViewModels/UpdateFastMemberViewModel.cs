namespace JHobby.Website.Models.ViewModels
{
    public class UpdateFastMemberViewModel
    {
        public IFormFile? File { get; set; }

        public string? HeadShot { get; set; }

        public string? MemberName { get; set; }

        public string? NickName { get; set; }

        public string? Gender { get; set; }

        public string? IdentityCard { get; set; }

        public DateTime? Birthday { get; set; }

        public string? ActiveCity { get; set; }

        public string? ActiveArea { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? PersonalProfile { get; set; }
    }
}
