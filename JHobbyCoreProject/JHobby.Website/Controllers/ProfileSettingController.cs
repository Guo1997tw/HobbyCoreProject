using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ProfileSettingController : Controller
    {
        public IActionResult ProfileSetting()
        {
            return View();
        }
    }
}