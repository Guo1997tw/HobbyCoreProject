namespace JHobby.Service.Models
{
    public class QueryHotMemberModel
    {
		public int MemberId { get; set; }
		public string? NickName { get; set; }
		public string? HeadShot { get; set; }

		public decimal? Star { get; set; }
	}
}