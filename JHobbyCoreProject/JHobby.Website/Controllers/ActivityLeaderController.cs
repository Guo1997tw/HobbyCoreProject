using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
	public class ActivityLeaderController : Controller
	{
		private readonly IUserAuthenticationService _userAuthenticationService;

		public ActivityLeaderController(IUserAuthenticationService userAuthenticationService)
		{
			_userAuthenticationService = userAuthenticationService;
		}

		public IActionResult LeaderBuild()
		{
			try
			{
				ViewBag.buildMemberId = _userAuthenticationService.GetUserId();
			}
			catch (Exception)
			{

				throw new Exception("Error!");
			}

			return View();
		}

		[HttpPost]
		public IActionResult LeaderEdit([FromForm] int id)
        {
			try
			{
				//ViewBag.buildMemberId = _userAuthenticationService.GetUserId();

				ViewBag.ActivityId = id;

            }
			catch (Exception)
			{
				throw new Exception("Error!");
			}

            return View();
        }
    }
}