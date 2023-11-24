namespace JHobby.Website.Models.ViewModels
{
    public class QueryHotMemberViewModel
    {
		public int MemberId { get; set; }
		public string? NickName { get; set; }
		public string? HeadShot { get; set; }

		public decimal? Star { get; set; }
	}
}