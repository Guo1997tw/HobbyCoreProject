using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
	public class ActivityRepository: IActivityRepository
	{
		private readonly JhobbyContext _jhobbyContext;

		public ActivityRepository(JhobbyContext jhobbyContext)
		{
			_jhobbyContext = jhobbyContext;
		}

		public bool InsertActivityBuild(ActivityBuildDto activityBuildDto)
		{
			var mapper = new Activity			
			{
				ActivityCity = activityBuildDto.ActivityCity,
				ActivityArea = activityBuildDto.ActivityArea,
				ActivityLocation = activityBuildDto.ActivityLocation,
				StartTime = activityBuildDto.StartTime,
				MaxPeople = activityBuildDto.MaxPeople,
				CategoryId = activityBuildDto.CategoryId,
				CategoryTypeId = activityBuildDto.CategoryTypeId,
				JoinDeadLine = activityBuildDto.JoinDeadLine,
				JoinFee = activityBuildDto.JoinFee,
				ActivityNotes = activityBuildDto.ActivityNotes,
				ActivityId = activityBuildDto.ActivityId,
			};

			_jhobbyContext.Activities.Add(mapper);
			_jhobbyContext.SaveChanges();

			return true;
		}

	}
}
