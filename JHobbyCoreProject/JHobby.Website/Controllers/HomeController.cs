using JHobby.Website.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JHobby.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // [Authorize(Roles = "Member")]
        public IActionResult Index()
        {
            return View();
        }

        // Home/ConceptPage
        public IActionResult ConceptPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NotFounds()
        {
            return View();
        }
        public IActionResult leaderEdit()
        {
            return View();
        }


        public IActionResult Newcomer()
        {
            ViewData["Title"] = "新手上路";

            return View();
        }

		public IActionResult DashboardMenu()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}