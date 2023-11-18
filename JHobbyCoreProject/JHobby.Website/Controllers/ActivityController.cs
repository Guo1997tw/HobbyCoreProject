using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult ActivityPage()
        {
            return View();
        }
    }
}