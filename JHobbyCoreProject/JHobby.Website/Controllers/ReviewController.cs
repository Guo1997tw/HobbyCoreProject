using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
	public class ReviewController : Controller
	{
		public IActionResult Review()
		{
			ViewData["Title"] = "報名審核";
			return View();
		}
	}
}
