using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
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
        public IActionResult launchATeam(int id)
        {
			ViewData["Title"] = "開團紀錄";
            var model = new ReviewIdViewModel();
            model.MemberId = id;
			return View(model);
        }

        // MemberCenter/joinAGroup
        /// <summary>
        ///  TODO : 參團紀錄
        /// </summary>
        /// <returns></returns>
        public IActionResult joinAGroup()
        {
            return View();
        }

	}
}
