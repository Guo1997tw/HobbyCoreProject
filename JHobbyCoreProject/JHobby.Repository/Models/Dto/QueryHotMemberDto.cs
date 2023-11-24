namespace JHobby.Repository.Models.Dto
{
    public class QueryHotMemberDto
    {
		public int MemberId { get; set; }
		public string? NickName { get; set; }
		public int ActivityId { get; set; }
		public string? HeadShot { get; set; }
		public int? Fraction { get; set; }
	}
}