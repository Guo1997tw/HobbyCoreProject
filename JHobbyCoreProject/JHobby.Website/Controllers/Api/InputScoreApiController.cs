using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [EnableCors("allowCors")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class InputScoreApiController : ControllerBase
    {
        private readonly IinputScoreService _iInputScoreService;

        public InputScoreApiController(IinputScoreService iinputScoreService)
        {
            _iInputScoreService = iinputScoreService;
        }

        [HttpPost]
        public bool NewInputScoreById(InputScoreViewModel inputScoreViewModel)
        {
            var inputScore = new InputScoreModel
            {
                ActivityId = inputScoreViewModel.ActivityId,
                Fraction = inputScoreViewModel.Fraction,
                MemberId = inputScoreViewModel.MemberId,
            };

            return _iInputScoreService.NewInputScoreById(inputScore);
        }

    }
}
