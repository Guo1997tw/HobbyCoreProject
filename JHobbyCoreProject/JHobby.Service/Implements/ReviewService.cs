using JHobby.Repository.Interfaces;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
	public class ReviewService:IReviewService
	{
		private readonly IReviewRepository _reviewRepository;

		public ReviewService(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}
		public IEnumerable<ReviewModel>GetReviewList()
		{
			var resultDto = _reviewRepository.GetAll();
			var reviewModel = resultDto.Select(dto => new ReviewModel
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
