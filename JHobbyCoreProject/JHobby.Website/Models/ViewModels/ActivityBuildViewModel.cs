using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace JHobby.Website.Models.ViewModels
{
	public class ActivityBuildViewModel : IValidatableObject
	{
		public string ActivityName { get; set; } = null!;
		public string ActivityCity { get; set; } = null!;
		public string ActivityArea { get; set; } = null!;
		public string ActivityLocation { get; set; } = null!;
		public DateTime StartTime { get; set; }
		public int? MaxPeople { get; set; }
		public int CategoryId { get; set; }
		public int CategoryTypeId { get; set; }
		public DateTime JoinDeadLine { get; set; }
		public decimal JoinFee { get; set; }
		public string? ActivityNotes { get; set; }
		public int MemberId { get; set; }
		public string ActivityStatus { get; set; } = null!;
		public string Payment { get; set; } = null!;
		public DateTime Created { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (string.IsNullOrEmpty(ActivityName) && string.IsNullOrEmpty(ActivityCity))
			{
				yield return new ValidationResult(
					"開團名稱和開團縣市不可皆未填寫",
					new string[] { "ActivityName", "ActivityCity" });
			}
		}
	}
}
