using AutoMapper;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Service.Models.Dto;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
	[Route("[controller]/[action]")]			
	[ApiController]
	public class ActivityApiController : ControllerBase
	{
		private readonly IActivityService _activityService;
		private readonly IMapper _mapper;
		
		public ActivityApiController (IActivityService activityService, IMapper mapper)
		{
			_activityService = activityService;
			_mapper = mapper;
		}

		[HttpPost]
		public IActionResult InsertActivity(ActivityBuildViewModel activityBuildViewModel)
		{
			var mapper = new ActivityBuildModel			
			{
				ActivityName = activityBuildViewModel.ActivityName,
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
				MemberId = activityBuildViewModel.MemberId,
				ActivityStatus = activityBuildViewModel.ActivityStatus,
				Payment = activityBuildViewModel.Payment,
				Created = activityBuildViewModel.Created

			};

			var result=_activityService.CreateActivityBuild(mapper);

			return Ok(result);
		}

		/// <summary>
		/// 活動頁面查詢
		/// </summary>
		/// <param name="id"></param>
		/// <param name="activityName"></param>
		/// <returns></returns>
		[HttpGet("{id}/{activityName}")]
		public ActionResult <ActivityPageViewModel> ActivitySearch(int id, string activityName)
		{
			var result = _activityService.GetActivityPageSearch(id, activityName);

			if (result == null) return NotFound("找不到此紀錄!!");

			return _mapper.Map<ActivityPageViewModel>(result);
		}
	}
}