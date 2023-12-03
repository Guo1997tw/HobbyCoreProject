using JHobby.Repository.Models.Dto;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Implements;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GroupStartingApiController : ControllerBase
    {
        private readonly IGroupStartingService _GroupStartingService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGroupStartingRepository _groupStartingRepository;
        public GroupStartingApiController(IGroupStartingService GroupStartingService, IWebHostEnvironment webHostEnvironment, IGroupStartingRepository groupStartingRepository)
        {
            _GroupStartingService = GroupStartingService;
            _webHostEnvironment = webHostEnvironment;
            _groupStartingRepository = groupStartingRepository;
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
        [HttpPut("{id}")]
        public IActionResult ActivityStatus(int id, ActivityStatusViewModel activityStatusViewModel)
        {
            var mapper = new ActivityStatusDto
            {
                ActivityStatus = activityStatusViewModel.ActivityStatus,
            };

            _groupStartingRepository.UpdateActivityStatus(id, mapper);
            return Ok(mapper);
        }
        [HttpGet("{id}")]
        public IEnumerable<GroupStartingViewModel> GetByIdNow(int id)
        {
            var Dto = _GroupStartingService.GetByIdNow(id);

            var viewModel = Dto.Select(x => new GroupStartingViewModel
            {
                MemberId = x.MemberId,
                ActivityId = x.ActivityId,

                ReviewStatus = x.ReviewStatus,
                ActivityName = x.ActivityName,
                CurrentPeople = x.CurrentPeople,
                ActivityStatus = x.ActivityStatus,
                StartTime = x.StartTime,
                MaxPeople = x.MaxPeople,
                IsCover = x.IsCover,
                ImageName = x.ImageName,
                ActivityImageId = x.ActivityImageId,
                DateConvert = x.DateConvert,
                TimeConvert = x.TimeConvert,


            });

			return viewModel;
		}

        [HttpGet("{id}/{ActivityId}")]
        public IEnumerable<GroupStartingCurrentViewModel> CurrentById(int id, int ActivityId)
        {
            var resultDto = _GroupStartingService.CurrentById(id, ActivityId);
            var reviewModel = resultDto.Select(dto => new GroupStartingCurrentViewModel
            {
                ActivityId = dto.ActivityId,
                LeaderId = dto.LeaderId,
                ActivityName = dto.ActivityName,
                ReviewStatus = dto.ReviewStatus,
                ReviewTime = dto.ReviewTime,
                ApplicantId = dto.ApplicantId,
                ActivityImageId = dto.ActivityImageId,
                ImageName = dto.ImageName,
                IsCover = dto.IsCover,
                NickName = dto.NickName,
                HeadShot = dto.HeadShot,
                DateConvert = dto.DateConvert,
                TimeConvert = dto.TimeConvert,
            });
            return reviewModel;
        }
    }
}
