using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ProfileSettingController : Controller
    {
        public IActionResult ProfileSetting(int id)
        {
            ViewBag.memberid=id;
            return View();
        }
    }
}