using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly JhobbyContext _jhobbyContext;
		public ReviewRepository(JhobbyContext jhobbyContext)
		{
			_jhobbyContext = jhobbyContext;
		}
		public IEnumerable<ReviewDto> GetAll()
		{
			var Dtoresult = _jhobbyContext.Activities.Join(_jhobbyContext.ActivityUsers, a => a.ActivityId, au => au.ActivityId, (a, au) => new
			{
				ActivityId = a.ActivityId,
				LeaderId = a.MemberId,
				ActivityName = a.ActivityName,
				ReviewStatus = au.ReviewStatus,
				ReviewTime = au.ReviewTime,
				ApplicantId = au.MemberId,
			}).Join(_jhobbyContext.ActivityImages, aau => aau.ActivityId, ai => ai.ActivityId, (aau, ai) => new
			{
				ActivityId = aau.ActivityId,
				LeaderId = aau.LeaderId,
				ActivityName = aau.ActivityName,
				ReviewStatus = aau.ReviewStatus,
				ReviewTime = aau.ReviewTime,
				ApplicantId = aau.ApplicantId,
				ActivityImageId = ai.ActivityImageId,
				ImageName = ai.ImageName,
				IsCover = ai.IsCover,
			}).Join(_jhobbyContext.Members, aaui => aaui.ApplicantId, m => m.MemberId, (aaui, m) => new ReviewDto
			{
				ActivityId = aaui.ActivityId,
				LeaderId = aaui.LeaderId,
				ActivityName = aaui.ActivityName,
				ReviewStatus = aaui.ReviewStatus,
				ReviewTime = aaui.ReviewTime,
				ApplicantId = aaui.ApplicantId,
				ActivityImageId = aaui.ActivityImageId,
				ImageName = aaui.ImageName,
				IsCover = aaui.IsCover,
				NickName = m.NickName,
				HeadShot = m.HeadShot,
			}); return Dtoresult;
		}
	}
}
