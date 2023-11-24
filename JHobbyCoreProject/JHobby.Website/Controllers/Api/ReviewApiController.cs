using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewApiController : ControllerBase
	{
		private readonly IReviewService _reviewService;

		public ReviewApiController(IReviewService reviewService)
		{
			_reviewService = reviewService;
		}
		[HttpGet]
		public IEnumerable<ReviewViewModel> GetReviewAll()
		{
			var resultDto = _reviewService.GetReviewList();
			var reviewModel = resultDto.Select(dto => new ReviewViewModel
			{
				ActivityId = dto.ActivityId,
				LeaderId = dto.LeaderId,
				ActivityName = dto.ActivityName,
				ReviewStatus = dto.ReviewStatus,
				ReviewTime = dto.ReviewTime,
				ApplicantId = dto.ApplicantId,
				ActivityImageId = dto.ActivityImageId,
				ImageName = dto.ImageName,
				IsCover = dto.IsCover,
				NickName = dto.NickName,
				HeadShot = dto.HeadShot,
			});
			return reviewModel;
		}
	}
}
