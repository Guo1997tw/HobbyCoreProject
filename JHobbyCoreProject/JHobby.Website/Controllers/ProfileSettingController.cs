using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ProfileSettingController : Controller
    {
        [Route("ProfileSetting")]
        public IActionResult ProfileSetting()
        {
            return View();
        }
    }
}
