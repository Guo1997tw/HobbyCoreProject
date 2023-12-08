using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class MemberCenterController : Controller
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public MemberCenterController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        // MemberCenter/launchATeam
        /// <summary>
        /// TODO : 開團紀錄
        /// </summary>
        [Authorize(Roles = "Member, FastMember,Admin")]
        public IActionResult launchATeam(int id)
        {
			ViewData["Title"] = "開團紀錄";
            var model = new ReviewIdViewModel();
            model.MemberId = _userAuthenticationService.GetUserId();
			return View(model);
        }
        // MemberCenter/joinAGroup
        /// <summary>
        ///  TODO : 參團紀錄
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Member, FastMember,Admin")]
        public IActionResult joinAGroup()
        {
            ViewBag.loginMemberId = _userAuthenticationService.GetUserId();
            return View();
        }
    }
}
