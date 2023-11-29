using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
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
		[HttpGet("{id}")]
		public IEnumerable<ReviewViewModel> GetReviewById(int id)
		{
			var resultDto = _reviewService.GetById(id);
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

		[HttpPut("{ActivityId}/{ApplicantId}")]
		public ActionResult Update(int ActivityId, int ApplicantId, [FromForm] ReviewStatusViewModel reviewStatusViewModel)
		{
			var mapping = new ReviewStatusModel
            {
				ReviewStatus = reviewStatusViewModel.ReviewStatus,
			};


            _reviewService.UpdateReviewStatus(ActivityId, ApplicantId, mapping);

			return Ok("修改成功");
		}
	}
}
