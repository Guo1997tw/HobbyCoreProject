using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}