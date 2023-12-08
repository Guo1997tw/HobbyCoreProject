using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JHobby.Website.Controllers.Api
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class MiddleCenterApiController : ControllerBase
	{
		private readonly IMiddleCenterService _middleCenterService;
		public MiddleCenterApiController(IMiddleCenterService middleCenterService)
		{
			_middleCenterService = middleCenterService;
		}
		// GET: api/<MiddleCenterApiController>
		[HttpPost]
		public IEnumerable<QueryCategoryTypeViewModel> GetCategoryTypeList([FromForm] SearchModel search)
		{
			var services = _middleCenterService.GetCategoryTypeResult(search);
			var viewModel = services.Select(s => new QueryCategoryTypeViewModel
			{
				ActivityId = s.ActivityId,
				MemberId = s.MemberId,
				NickName = s.NickName,
                HeadShot=s.HeadShot,
                CategoryId = s.CategoryId,
				CategoryTypeId = s.CategoryTypeId,
				ActivityName = s.ActivityName,
				ActivityStatus = s.ActivityStatus,
				ActivityLocation = s.ActivityLocation,
				ActivityNotes = s.ActivityNotes,
				ShotActivityNotes = s.ShotActivityNotes,
				JoinDeadLine = s.JoinDeadLine,
				ActivityImages = s.ActivityImages
			});
			return viewModel;
		}


	}
}
