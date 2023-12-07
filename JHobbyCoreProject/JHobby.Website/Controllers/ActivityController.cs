using JHobby.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IUserAuthenticationService _userAuthenticationService;
        public ActivityController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        [Authorize(Roles = "Member")]
        //[Authorize(Roles = "Admin")]
        public IActionResult ActivityPage(int id)
        {
            ViewData["Title"] = "活動說明";
            ViewBag.activityId = id;
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
    }
}