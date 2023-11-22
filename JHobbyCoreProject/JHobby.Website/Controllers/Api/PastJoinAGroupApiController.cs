using JHobby.Repository.Interfaces;
using JHobby.Service.Implements;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [EnableCors("AllowOrigin")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PastJoinAGroupApiController : ControllerBase
    {
        private readonly IPastJoinAGroupService _iPastJoinAGroupService;

        public PastJoinAGroupApiController(IPastJoinAGroupService iPastJoinAGroupService)
        {
            _iPastJoinAGroupService = iPastJoinAGroupService;
        }

        [HttpGet]
        public IEnumerable<PastJoinAGroupViewModel> GetPastJoinAGroupList()
        {
            var serviceDto = _iPastJoinAGroupService.GetPastJoinAGroupsList();

            var viewModel = serviceDto.Select(s => new PastJoinAGroupViewModel
            {
                ActivityName = s.ActivityName,
                ActivityStatus = s.ActivityStatus,
                ActivityCity = s.ActivityCity,
                CurrentPeople = s.CurrentPeople,
                StartTime = s.StartTime,
                NickName = s.NickName,
            });

            return viewModel;
        }
    }
}
