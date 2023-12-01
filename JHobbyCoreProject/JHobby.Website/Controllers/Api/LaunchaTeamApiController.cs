using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

		[HttpGet("{id}")]
		public IEnumerable<LaunchaTeamViewModel> GetByIdOld(int id)
		{
            var Dto = _LaunchaTeamService.GetByIdOld(id);

            var viewModel = Dto.Select(x => new LaunchaTeamViewModel
            {
                MemberId = x.MemberId,
                ActivityName = x.ActivityName,
                CurrentPeople = x.CurrentPeople,
                ActivityStatus = x.ActivityStatus,
                StartTime = x.StartTime,
                IsCover = x.IsCover,
                ImageName = x.ImageName,
                ActivityImageId = x.ActivityImageId,


            });

            return viewModel;
        }
		//public async Task<IEnumerable<LaunchaTeamViewModel>> Filter([FromBody] LaunchaTeamViewModel launchaTeamViewModel)
		//{
		//	return _LaunchaTeamService.LaunchaTeamModel.Where(l => l.ActivityName == launchaTeamViewModel.ActivityName || l.launchaTeamViewModel.Contains(launchaTeamViewModel.ActivityStatus))
		//	.Select(l => l);
		//}




	}
}
