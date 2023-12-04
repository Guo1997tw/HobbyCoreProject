using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
	//[Route("/{controller}/{action}/{_categoyId}/{_categoryTypeId}/{_city}/{_area}")]

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
                ViewBag.memberId = _userAuthenticationService.GetUserId();
            }
            catch (Exception)
            {
                ViewBag.logIn = false;
                ViewBag.memberId = 0;
            }
            ViewBag.search = SearchArgs;
			return View();
		}
	}
}
