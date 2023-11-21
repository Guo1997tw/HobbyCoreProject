using JHobby.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JHobby.Website.Controllers.Api
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class WishApiController : ControllerBase
	{
		private readonly IWishService _WishService;

		public WishApiController(IWishService WishService)
		{
			_WishService = WishService;
		}
		// GET: api/<WishApiController>
		[HttpGet]
		public int[] GetWishList()
		{
			var id = 1;
			var services = _WishService.GetWishByIdResult(id);
			var viewModel = services.Select(s => s.ActivityId).ToArray();
			return viewModel;
		}

		[HttpDelete("{activityId}")]
		public IActionResult DeleteWish(int activityId)
		{
			var memberId = 1;
			if (memberId <= 0 || activityId <= 0) { return BadRequest(); }

			var result = _WishService.DeleteWish(memberId, activityId);

			return Ok(result);
		}
	}
}
