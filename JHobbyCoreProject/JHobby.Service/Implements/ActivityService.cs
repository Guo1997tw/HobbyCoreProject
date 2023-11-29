using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Service.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
	public class ActivityService:IActivityService
	{
		public readonly IActivityRepository _activityRepository;
		private readonly IMapper _mapper;
		
		public ActivityService (IActivityRepository activityRepository, IMapper mapper)
		{
			_activityRepository = activityRepository;
			_mapper = mapper;
		}

		public bool CreateActivityBuild(ActivityBuildModel activityBuildModel)
		{
			var mapper = new ActivityBuildDto
			{
				ActivityName = activityBuildModel.ActivityName,
				ActivityCity = activityBuildModel.ActivityCity,
				ActivityArea = activityBuildModel.ActivityArea,
				ActivityLocation = activityBuildModel.ActivityLocation,
				StartTime = activityBuildModel.StartTime,
				MaxPeople = activityBuildModel.MaxPeople,
				CategoryId = activityBuildModel.CategoryId,
				CategoryTypeId = activityBuildModel.CategoryTypeId,		
				JoinDeadLine = activityBuildModel.JoinDeadLine,
				JoinFee = activityBuildModel.JoinFee,
				ActivityNotes = activityBuildModel.ActivityNotes,
				MemberId = activityBuildModel.MemberId,
				ActivityStatus = activityBuildModel.ActivityStatus,
				Payment = activityBuildModel.Payment,
				Created = activityBuildModel.Created
			};
			_activityRepository.InsertActivityBuild(mapper);
			return true;
		}

		/// <summary>
		/// 活動頁面查詢
		/// </summary>
		/// <param name="id"></param>
		/// <param name="activityName"></param>
		/// <returns></returns>
		public ActivityPageModel GetActivityPageSearch(int id)
		{
			var result = _activityRepository.GetActivityPageById(id);

			var mapper = new ActivityPageModel
			{
                ActivityId = result.ActivityId,
				MemberId = result.MemberId,
                ActivityLocation = result.ActivityLocation,
                CategoryId = result.CategoryId,
                CategoryTypeId = result.CategoryTypeId,
                ActivityName = result.ActivityName,
                StartTime = result.StartTime,
                JoinDeadLine = result.JoinDeadLine,
                ActivityNotes = result.ActivityNotes,
                ActivityImages = result.ActivityImages.Select(ai => new ActivityImageModel
                {
                    ActivityImageId = ai.ActivityImageId,
					AiActivity = ai.AiActivity,
                    ImageName = ai.ImageName,
                    IsCover = ai.IsCover,
                    UploadTime = ai.UploadTime,
                })
            };

            return mapper;
		}

		public IEnumerable<MemberMsgModel> GetMemberMsg(int id)
		{
			return _activityRepository.GetMsgList(id).Select(r => new MemberMsgModel
			{
				ActivityId=r.ActivityId,
				HeadShot = r.HeadShot,
				MessageTime = r.MessageTime,
				MessageText = r.MessageText,
				NickName = r.NickName,
			}).ToList();
		}
	}
}