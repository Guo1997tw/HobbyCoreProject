using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
	[ApiController]
	public class WishApiController : ControllerBase
	{
		private readonly IWishService _WishService;


        public WishApiController(IWishService WishService, IWishRepository wishRepository)
		{
			_WishService = WishService;
		}
		// GET: api/<WishApiController>
		[HttpGet("{id}")]
		public int[] GetWishList(int id)
		{
			var services = _WishService.GetWishByIdResult(id);
			var viewModel = services.Select(s => s.ActivityId).ToArray();
			return viewModel;
		}

		[HttpPost]
		public IActionResult InsertWish([FromForm] CreateWishViewModel createWishViewModel)
		{
			var mapper = new CreateWishModel
			{
				MemberId = createWishViewModel.MemberId,
				ActivityId = createWishViewModel.ActivityId,
				AddTime = createWishViewModel.AddTime,
			};

			var result = _WishService.CreateWish(mapper);

			return Ok(result);
		}

		[HttpDelete("{memberId}/{activityId}")]
		public IActionResult DeleteWish(int memberId ,int activityId)
		{

			if (memberId <= 0 || activityId <= 0) { return BadRequest(); }

			var result = _WishService.DeleteWish(memberId, activityId);

			return Ok(result);
		}
	}
}
