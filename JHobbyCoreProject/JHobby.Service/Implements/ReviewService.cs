﻿using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
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
        private readonly ICommonService _iCommonService;

        public ReviewService(IReviewRepository reviewRepository, ICommonService commonService)
		{
			_reviewRepository = reviewRepository;
            _iCommonService = commonService;
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
				ReviewTime = dto.ReviewTime.ToString("yyyy-MM-dd HH:mm:ss"),
                ApplicantId = dto.ApplicantId,
				ActivityImageId = dto.ActivityImageId,
				ImageName = dto.ImageName,
				IsCover = dto.IsCover,
				NickName = dto.NickName,
				HeadShot = dto.HeadShot,
			});
			return reviewModel;
		}
        public IEnumerable<ReviewModel> GetById(int id)
		{
			var resultDto= _reviewRepository.GetById(id);
			
			
			var reviewModel = resultDto.OrderByDescending(dto => dto.ReviewTime).Select(dto => new ReviewModel
            {
                ActivityId = dto.ActivityId,
                LeaderId = dto.LeaderId,
                ActivityName = dto.ActivityName.Trim(),
                ReviewStatus = dto.ReviewStatus,
                ReviewTime = dto.ReviewTime.ToString("yyyy-MM-dd HH:mm:ss"),
                ApplicantId = dto.ApplicantId,
                ActivityImageId = dto.ActivityImageId,
                ImageName = dto.ImageName,
                IsCover = dto.IsCover,
                NickName = dto.NickName,
                HeadShot = dto.HeadShot,
                DateConvert = _iCommonService.ConvertTime(dto.ReviewTime).First().DateConvert,
                TimeConvert = _iCommonService.ConvertTime(dto.ReviewTime).First().TimeConvert                
            });

            return reviewModel;
		}

		public bool UpdateReviewStatus(int ActivityId, int ApplicantId, ReviewStatusModel reviewStatusModel)
		{
            var mapping = new ReviewStatusDto
            {
                ReviewStatus = reviewStatusModel.ReviewStatus,
            };
            _reviewRepository.UpdateReviewStatus(ActivityId, ApplicantId, mapping);

             return true;
        }

	}
}
