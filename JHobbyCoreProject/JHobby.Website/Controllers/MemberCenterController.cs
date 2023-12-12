using JHobby.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    [Authorize(Roles = "Admin,Member,FastMember")]
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
        public IActionResult LaunchATeam()
        {
            ViewData["Title"] = "開團紀錄";
			ViewData["BookMark"] = "LaunchATeam";
			ViewBag.VerifyMemberId = _userAuthenticationService.GetUserId();
            return View();
        }
        // MemberCenter/joinAGroup
        /// <summary>
        ///  TODO : 參團紀錄
        /// </summary>
        /// <returns></returns>
        public IActionResult JoinAGroup()
        {
            ViewBag.VerifyMemberId = _userAuthenticationService.GetUserId();
			ViewData["BookMark"] = "JoinAGroup";
			return View();
        }
        // MemberCenter/MemberProfile
        /// <summary>
        ///  TODO : 個人資訊
        /// </summary>
        /// <returns></returns>
        public IActionResult MemberProfile(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("NotFounds", "ErrorPage");
            }
            ViewData["Title"] = "會員個人介紹";
            ViewBag.VerifyMemberId = _userAuthenticationService.GetUserId();
            ViewBag.MemberId = id;
			ViewData["BookMark"] = "MemberProfile";
			return View();
        }
        /// <summary>
        /// 個人資訊修改
        /// </summary>
        /// <returns></returns>
        public IActionResult ProfileSetting()
        {
            ViewBag.VerifyMemberId = _userAuthenticationService.GetUserId();
            ViewData["Title"] = "編輯資訊";
            ViewData["BookMark"] = "ProfileSetting";
            return View();
        }
        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <returns></returns>
        public IActionResult ChangePwd()
        {
            ViewData["BookMark"] = "ChangePwd";
            ViewBag.VerifyMemberId = _userAuthenticationService.GetUserId();
            return View();
        }
        /// <summary>
        /// 報名審核
        /// </summary>
        /// <returns></returns>
        public IActionResult Apply()
        {
            ViewData["Title"] = "報名審核";
			ViewData["BookMark"] = "Apply";
			ViewBag.VerifyMemberId = _userAuthenticationService.GetUserId();
            return View();
        }
    }
}
