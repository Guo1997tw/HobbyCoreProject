using JHobby.Repository.Models.Dto;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class GroupStartingApiController : ControllerBase
	{
		private readonly IGroupStartingService _GroupStartingService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GroupStartingApiController(IGroupStartingService GroupStartingService , IWebHostEnvironment webHostEnvironment)
		{
			_GroupStartingService = GroupStartingService;
            _webHostEnvironment = webHostEnvironment;

        }

		[HttpGet]
		public IEnumerable<GroupStartingViewModel> GetAll()
		{
			return _GroupStartingService.GetGroupStartingAll()
				.Select(a => new GroupStartingViewModel
				{
					ActivityId = a.ActivityId,
					ActivityName = a.ActivityName,
					CurrentPeople = a.CurrentPeople,
					ActivityStatus = a.ActivityStatus,
					StartTime = a.StartTime,
					MaxPeople = a.MaxPeople,
					IsCover = a.IsCover,
					ImageName = a.ImageName,
					ActivityImageId = a.ActivityImageId,
				});
		}
		
		[HttpPut("{CurrentPeople}")]
		public IActionResult UpdateGroupStarting(int CurrentPeople, [FromBody] GroupStartingModel GroupStartingModel)
		{
			if (CurrentPeople < 0) { return BadRequest(); }

			var mapper = new GroupStartingModel
			{
				CurrentPeople = GroupStartingModel.CurrentPeople
			};

			var result = _GroupStartingService.Update(CurrentPeople, mapper);

			return Ok(result);
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if (id < 0) { return BadRequest(); }

			var result = _GroupStartingService.Delete(id);

			return Ok(result);
		}
		[HttpGet("{id}")]
		public IEnumerable<GroupStartingViewModel> GetById(int id)
		{
			var Dto = _GroupStartingService.GetById(id);

			var viewModel = Dto.Select(x=> new GroupStartingViewModel 
			{
				MemberId = x.MemberId,
				ActivityId = x.ActivityId,
				ActivityName = x.ActivityName,
				CurrentPeople = x.CurrentPeople,
				ActivityStatus = x.ActivityStatus,
				StartTime = x.StartTime,
				MaxPeople = x.MaxPeople,
				IsCover = x.IsCover,
				ImageName =x.ImageName,
				ActivityImageId = x.ActivityImageId,


			});

			return viewModel;
		}
	}
}
