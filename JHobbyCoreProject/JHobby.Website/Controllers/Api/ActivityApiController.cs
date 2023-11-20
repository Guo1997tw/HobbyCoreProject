using JHobby.Repository.Models.Dto;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Service.Models.Dto;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActivityApiController : ControllerBase
	{
		private readonly IActivityService _activityService;
		
		public ActivityApiController (IActivityService activityService)
		{
			_activityService = activityService;
		}

		[HttpPost]
		public IActionResult InsertActivity(ActivityBuildViewModel activityBuildViewModel)
		{
			var mapper = new ActivityBuildModel
			{
				ActivityCity = activityBuildViewModel.ActivityCity,
				ActivityArea = activityBuildViewModel.ActivityArea,
				ActivityLocation = activityBuildViewModel.ActivityLocation,
				StartTime = activityBuildViewModel.StartTime,
				MaxPeople = activityBuildViewModel.MaxPeople,
				CategoryId = activityBuildViewModel.CategoryId,
				CategoryTypeId = activityBuildViewModel.CategoryTypeId,
				JoinDeadLine = activityBuildViewModel.JoinDeadLine,
				JoinFee = activityBuildViewModel.JoinFee,
				ActivityNotes = activityBuildViewModel.ActivityNotes,
				ActivityId = activityBuildViewModel.ActivityId,
			};

			var result=_activityService.CreateActivityBuild(mapper);

			return Ok(result);
		}




	}
}
