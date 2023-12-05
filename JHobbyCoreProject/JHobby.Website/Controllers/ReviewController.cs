using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
	public class ReviewController : Controller
	{

		public IActionResult Apply(int id)
		{
			ViewData["Title"] = "報名審核";
            return View(new ReviewIdViewModel
            {
                LeaderId = id
            });
            
		}
	}
}
