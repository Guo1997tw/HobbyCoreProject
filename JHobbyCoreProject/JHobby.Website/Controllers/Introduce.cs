using JHobby.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class Introduce : Controller
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public Introduce(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        public IActionResult Newcomer()
        {
            ViewData["Title"] = "新手上路";
            try
            {
                ViewBag.verifyMemberId = _userAuthenticationService.GetUserId();
            }
            catch (Exception)
            {

                return View();
            }

            return View();
        }

		// Home/ConceptPage
		public IActionResult ConceptPage()
		{
			try
			{
				ViewBag.verifyMemberId = _userAuthenticationService.GetUserId();
			}
			catch (Exception)
			{

				return View();
			}

			return View();
		}
	}
}