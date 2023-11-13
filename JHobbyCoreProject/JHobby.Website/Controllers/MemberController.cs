using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}