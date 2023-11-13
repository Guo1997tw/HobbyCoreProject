using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    [Route("[controller]/[action]")]
    public class MemberController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}