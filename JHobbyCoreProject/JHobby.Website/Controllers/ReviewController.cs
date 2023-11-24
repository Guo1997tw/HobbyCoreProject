using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
	public class ReviewController : Controller
	{
		public IActionResult Apply()
		{
			ViewData["Title"] = "報名審核";
			return View();
		}
	}
}
