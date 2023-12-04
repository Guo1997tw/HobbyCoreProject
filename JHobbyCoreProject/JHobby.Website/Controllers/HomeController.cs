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
                ViewBag.memberId = _userAuthenticationService.GetUserId();
            }
            catch (Exception)
            {
                ViewBag.logIn = false;
                ViewBag.memberId = 0;
            }
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

        public IActionResult changePassword()
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