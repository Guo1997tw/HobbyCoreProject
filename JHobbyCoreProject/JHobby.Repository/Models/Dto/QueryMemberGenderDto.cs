namespace JHobby.Repository.Models.Dto
{
    public class QueryMemberGenderDto
    {
		public int MemberId { get; set; }
		public string? Gender { get; set; }
		public string Status { get; set; } = null!;
	}
}