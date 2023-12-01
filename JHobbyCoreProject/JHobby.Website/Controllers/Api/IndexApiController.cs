using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JHobby.Website.Controllers.Api
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class IndexApiController : ControllerBase
	{

		private readonly IIndexService _IndexService;

		public IndexApiController(IIndexService IndexService)
		{
			_IndexService = IndexService;
		}

		// GET: api/<IndexApiController>
		[HttpGet]
		public IEnumerable<QueryMemberGenderViewModel> GetGenderList()
		{
			var services = _IndexService.GetGenderResult();
			var viewModel = services.Select(s => new QueryMemberGenderViewModel
			{
				Totle = s.Totle,
				Man = s.Man,
				Woman = s.Woman
			});
			return viewModel;
		}

		[HttpGet]
		public IEnumerable<QueryActivityViewModel> getActivityList()
		{
			var services = _IndexService.GetActivityResult();
			var viewModel = services.Select(s => new QueryActivityViewModel
			{
				ActivityId = s.ActivityId,
				MemberId = s.MemberId,
				NickName = s.NickName,
				ActivityName = s.ActivityName,
				ActivityStatus = s.ActivityStatus,
				ActivityLocation = s.ActivityLocation,
				ActivityNotes = s.ActivityNotes,
                ShotActivityNotes=s.ShotActivityNotes,
                JoinDeadLine = s.JoinDeadLine,
				ActivityImages = s.ActivityImages
			});
			return viewModel;
		}

		[HttpGet]
		public IEnumerable<QueryHotMemberViewModel> GetHotMemberList()
		{
			var services = _IndexService.GetHotMemberResult();
			var viewModel = services.Select(s => new QueryHotMemberViewModel
			{
				MemberId = s.MemberId,
				NickName = s.NickName,
				HeadShot = s.HeadShot,
				Star = s.Star,
			});
			return viewModel;
		}
	}
}
