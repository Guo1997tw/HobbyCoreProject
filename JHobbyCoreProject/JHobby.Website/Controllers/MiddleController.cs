using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{

	public class MiddleController : Controller
	{
        private readonly IUserAuthenticationService _userAuthenticationService;
        public MiddleController (IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }
		[HttpPost]
		public IActionResult ActivityCenter([FromForm] SearchArgsViewModel SearchArgs)
		{
            try
            {
                ViewBag.logIn = true;
                ViewBag.verifyMemberId = _userAuthenticationService.GetUserId();
            }
            catch (Exception)
            {
                ViewBag.logIn = false;
                ViewBag.verifyMemberId = 0;
            }
            ViewBag.search = SearchArgs;
			return View();
		}
	}
}
