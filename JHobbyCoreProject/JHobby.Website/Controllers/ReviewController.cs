using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
	public class ReviewController : Controller
	{
		private readonly IUserAuthenticationService _userAuthenticationService;
		public ReviewController(IUserAuthenticationService userAuthenticationService)
		{
			_userAuthenticationService = userAuthenticationService;
		}
		public IActionResult Apply(int id)
		{
			ViewData["Title"] = "報名審核";

            return View(new ReviewIdViewModel
            {
                MemberId =_userAuthenticationService.GetUserId(),
            });
            
		}
	}
}
