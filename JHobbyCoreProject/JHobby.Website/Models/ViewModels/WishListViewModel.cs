namespace JHobby.Website.Models.ViewModels
{
    public class WishListViewModel
    {
        public int WishId { get; set; }

        public int MemberId { get; set; }

        //活動狀態
        public string ActivityStatus { get; set; } = null!;

        public string ActivityName { get; set; } = null!;

        public int SurplusQuota { get; set;}
    }
}
