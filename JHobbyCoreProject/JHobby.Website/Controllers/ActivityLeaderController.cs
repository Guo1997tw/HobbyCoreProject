using JHobby.Service.Interfaces;
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
		public IActionResult LeaderEdit()
        {
            return View();
        }
    }
}