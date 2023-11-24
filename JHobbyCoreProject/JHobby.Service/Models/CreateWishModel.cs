namespace JHobby.Service.Models
{
    public class CreateWishModel
    {
		public int MemberId { get; set; }

		public int ActivityId { get; set; }

		public DateTime AddTime { get; set; }
	}
}