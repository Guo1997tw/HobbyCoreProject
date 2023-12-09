using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult NotFounds()
        {
            return View();
        }

        public IActionResult NotPermissions()
        {
            return View();
        }
    }
}