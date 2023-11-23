using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
	//[Route("/{controller}/{action}/{_categoyId}/{_categoryTypeId}/{_city}/{_area}")]

	public class MiddleController : Controller
	{
		[HttpPost]
		public IActionResult ActivityCenter([FromForm] SearchArgsViewModel SearchArgs)
		{
			ViewBag.search = SearchArgs;
			return View();
		}
	}
}
