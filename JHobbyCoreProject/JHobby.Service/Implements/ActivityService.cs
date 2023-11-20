using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
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
		
		public ActivityService (IActivityRepository activityRepository)
		{
			_activityRepository = activityRepository;
		} 
		public bool CreateActivityBuild(ActivityBuildModel activityBuildModel)
		{
			var mapper = new ActivityBuildDto
			{
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
				ActivityId = activityBuildModel.ActivityId,
			};
			_activityRepository.InsertActivityBuild(mapper);
			return true;
		}

	}
}
