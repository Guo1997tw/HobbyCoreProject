using JHobby.Service.Interfaces;
using JHobby.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JHobby.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public HomeController(ILogger<HomeController> logger, IUserAuthenticationService userAuthenticationService)
        {
            _logger = logger;
            _userAuthenticationService = userAuthenticationService;
        }

        // [Authorize(Roles = "Member")]
        public IActionResult Index()
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult leaderEdit()
        {
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