using JHobby.Repository.Interfaces;
using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class LaunchaTeamApiController : ControllerBase
	{

		private readonly ILaunchaTeamService _LaunchaTeamService;
		private readonly IWebHostEnvironment _webHostEnvironment;  //內建不用DI註冊
		public LaunchaTeamApiController(ILaunchaTeamService LaunchaTeamService , IWebHostEnvironment webHostEnvironment)
		{
			_LaunchaTeamService = LaunchaTeamService;
			_webHostEnvironment = webHostEnvironment;

        }

		[HttpGet]
		public IEnumerable<LaunchaTeamViewModel> GetAll()
		{
			return _LaunchaTeamService.GetAll()
				.Select(a => new LaunchaTeamViewModel
			{
				MemberId = a.MemberId,
				ActivityName = a.ActivityName,
				ActivityStatus = a.ActivityStatus,
				StartTime = a.StartTime,
				Created = a.Created,
				IsCover = a.IsCover,
				ImageName = a.ImageName,
				ActivityImageId = a.ActivityImageId,
			});
		}


	}
}
