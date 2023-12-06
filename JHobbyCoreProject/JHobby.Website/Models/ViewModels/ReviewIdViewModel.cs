namespace JHobby.Website.Models.ViewModels
{
    public class ReviewIdViewModel
    {
        public int LeaderId { get; set; }  //團主Id

        public int ApplicantId { get; set; } //申請者Id
        public int ActivityId { get; set; }
        public int MemberId { get; set; }
    }
}
