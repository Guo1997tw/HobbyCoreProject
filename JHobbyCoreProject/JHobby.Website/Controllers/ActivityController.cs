using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
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

        [Authorize(Roles = "Member,Admin")]
        //[Authorize(Roles = "Admin")]
        public IActionResult ActivityPage(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("NotFounds", "ErrorPage");
            }
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

        [HttpPost]
        public IActionResult ActivityCenter([FromForm] SearchArgsViewModel SearchArgs)
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
            ViewBag.search = SearchArgs;
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult LeaderBuild()
        {
            try
            {
                ViewBag.buildMemberId = _userAuthenticationService.GetUserId();
            }
            catch (Exception)
            {

                throw new Exception("Error!");
            }

            return View();
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public IActionResult LeaderEdit([FromForm] int id)
        {
            try
            {
                //ViewBag.buildMemberId = _userAuthenticationService.GetUserId();

                ViewBag.ActivityId = id;

            }
            catch (Exception)
            {
                throw new Exception("Error!");
            }

            return View();
        }
    }
}