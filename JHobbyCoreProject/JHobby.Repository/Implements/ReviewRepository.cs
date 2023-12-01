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
        public IEnumerable<ReviewDto> GetById(int id)
        {
            //主表為Activities
            //var Dtoresult = _jhobbyContext.Activities.Join(_jhobbyContext.ActivityUsers, a => a.ActivityId, au => au.ActivityId, (a, au) => new
            //{
            //    ActivityId = a.ActivityId,
            //    LeaderId = a.MemberId,
            //    ActivityName = a.ActivityName,
            //    ReviewStatus = au.ReviewStatus,
            //    ReviewTime = au.ReviewTime,
            //    ApplicantId = au.MemberId,
            //}).Join(_jhobbyContext.ActivityImages, aau => aau.ActivityId, ai => ai.ActivityId, (aau, ai) => new
            //{
            //    ActivityId = aau.ActivityId,
            //    LeaderId = aau.LeaderId,
            //    ActivityName = aau.ActivityName,
            //    ReviewStatus = aau.ReviewStatus,
            //    ReviewTime = aau.ReviewTime,
            //    ApplicantId = aau.ApplicantId,
            //    ActivityImageId = ai.ActivityImageId,
            //    ImageName = ai.ImageName,
            //    IsCover = ai.IsCover,
            //}).Join(_jhobbyContext.Members, aaui => aaui.ApplicantId, m => m.MemberId, (aaui, m) => new ReviewDto
            //{
            //    ActivityId = aaui.ActivityId,
            //    LeaderId = aaui.LeaderId,
            //    ActivityName = aaui.ActivityName,
            //    ReviewStatus = aaui.ReviewStatus,
            //    ReviewTime = aaui.ReviewTime,
            //    ApplicantId = aaui.ApplicantId,
            //    ActivityImageId = aaui.ActivityImageId,
            //    ImageName = aaui.ImageName,
            //    IsCover = aaui.IsCover,
            //    NickName = m.NickName,
            //    HeadShot = m.HeadShot,
            //}).Where(d => d.LeaderId == id);

            //主表為Members
            var Dtoresult = _jhobbyContext.Members.Join(_jhobbyContext.ActivityUsers, m => m.MemberId, au => au.MemberId, (m, au) => new
            {
                ApplicantId = m.MemberId,
                NickName = m.NickName,
                HeadShot = m.HeadShot,
                ReviewStatus = au.ReviewStatus,
                ReviewTime = au.ReviewTime,
                ActivityId = au.ActivityId,
            }).Join(_jhobbyContext.Activities, mau => mau.ActivityId, a => a.ActivityId, (mau, a) => new
            {
                ApplicantId = mau.ApplicantId,
                NickName = mau.NickName,
                HeadShot = mau.HeadShot,
                ReviewStatus = mau.ReviewStatus,
                ReviewTime = mau.ReviewTime,
                ActivityId = mau.ActivityId,
                ActivityName = a.ActivityName,
                LeaderId = a.MemberId,
            }).Join(_jhobbyContext.ActivityImages, maua => maua.ActivityId, ai => ai.ActivityId, (maua, ai) => new ReviewDto
            {
                ApplicantId = maua.ApplicantId,
                NickName = maua.NickName,
                HeadShot = maua.HeadShot,
                ReviewStatus = maua.ReviewStatus,
                ReviewTime = maua.ReviewTime,
                ActivityId = maua.ActivityId,
                ActivityName = maua.ActivityName,
                LeaderId = maua.LeaderId,
                ImageName = ai.ImageName,
                IsCover = ai.IsCover,
                ActivityImageId = ai.ActivityImageId,
            }).Where(d => d.LeaderId == id && d.ReviewStatus == "0");
            return Dtoresult;
        }
        public bool UpdateReviewStatus(int ActivityId, int ApplicantId, ReviewStatusDto reviewStatusDto)
        {
            var queryResult = _jhobbyContext.ActivityUsers.FirstOrDefault(au => au.ActivityId == ActivityId && au.MemberId == ApplicantId);

            if (queryResult != null)
            {
                queryResult.ReviewStatus=reviewStatusDto.ReviewStatus;
                _jhobbyContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}