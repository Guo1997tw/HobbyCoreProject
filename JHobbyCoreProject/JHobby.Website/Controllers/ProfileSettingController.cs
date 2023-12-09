using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    [Authorize(Roles = "Admin,Member, FastMember")]
    public class ProfileSettingController : Controller
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public ProfileSettingController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        public IActionResult ProfileSetting()
        {
            ViewBag.memberId = _userAuthenticationService.GetUserId();
            ViewData["Title"] = "修改資訊";
            ViewData["BookMark"] = "ProfileSetting";
            return View();
        }

        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <returns></returns>
        public IActionResult ChangePwd()
        {
            ViewData["BookMark"] = "ChangePassword";
            ViewBag.memberId = _userAuthenticationService.GetUserId();

            return View();
        }
    }
}