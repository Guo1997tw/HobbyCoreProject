using JHobby.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ErrorPageController : Controller
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public ErrorPageController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }
        public IActionResult NotFounds()
        {
            ViewData["Title"] = "網站訊息";
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

        public IActionResult NotPermissions()
        {
            ViewData["Title"] = "網站訊息";
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