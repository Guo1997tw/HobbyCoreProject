using JHobby.Repository.Models.Entity;

namespace JHobby.Repository.Models.Dto
{
    public class QueryCategoryTypeDto
    {
		public int ActivityId { get; set; }
		public int MemberId { get; set; }
		public string? NickName { get; set; }
		public int CategoryId { get; set; }
		public int CategoryTypeId { get; set; }
		public string ActivityName { get; set; } = null!;
		public string ActivityStatus { get; set; } = null!;
		public string ActivityLocation { get; set; } = null!;
		public string? ActivityNotes { get; set; }
		public DateTime JoinDeadLine { get; set; }
		public virtual ICollection<ActivityImage> ActivityImages { get; set; } = new List<ActivityImage>();
		public string ActivityCity { get;  set; }
		public string ActivityArea { get;  set; }
	}
}