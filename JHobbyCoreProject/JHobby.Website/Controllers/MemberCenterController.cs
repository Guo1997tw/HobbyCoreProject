using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class MemberCenterController : Controller
    {
        
        // MemberCenter/launchATeam
        /// <summary>
        /// TODO : 開團紀錄
        /// </summary>
        public IActionResult launchATeam()
        {
			ViewData["Title"] = "開團紀錄";
			return View();
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
