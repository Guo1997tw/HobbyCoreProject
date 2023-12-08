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
        private readonly IUserAuthenticationService _UserAuthenticationService;
        public ProfileSettingController(IUserAuthenticationService userAuthenticationService)
        {
            _UserAuthenticationService = userAuthenticationService;
        }
        public IActionResult ProfileSetting()
        {
            ViewBag.memberId=_UserAuthenticationService.GetUserId();
            ViewData["Title"] = "修改資訊";
            ViewData["BookMark"] = "ProfileSetting";
            return View();
        }
    }
}