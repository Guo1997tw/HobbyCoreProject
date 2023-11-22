using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
	[Route("/{controller}/{action}/{searchType}/{arg1?}/{arg2?}")]

	public class MiddleController : Controller
	{
		[HttpGet]
		[HttpPost]
		public IActionResult ActivityCenter(string searchType, int arg1, int arg2)
		{
			if(searchType== "categoy")
			{
				ViewBag.search = new SearchCategoyViewModel
				{
					categoyId = arg1,
					categoryTypeId = arg2
				};
			}
			else
			{
				ViewBag.search = new SearchCityAreaViewModel
				{
					cityId = arg1,
					areaId = arg2
				};
			}

			return View();
		}
	}
}
