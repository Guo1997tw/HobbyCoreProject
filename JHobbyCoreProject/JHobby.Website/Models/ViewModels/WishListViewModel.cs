namespace JHobby.Website.Models.ViewModels
{
    public class WishListViewModel
    {
        //活動狀態
        public string ActivityStatus { get; set; } = null!;

        public string ActivityName { get; set; } = null!;

        public string? NickName { get; set; }

        public int SurplusQuota { get; set;}
    }
}
