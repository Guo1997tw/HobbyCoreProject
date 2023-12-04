using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
	public class ActivityLeaderController : Controller
	{
		public IActionResult LeaderBuild()
		{
			return View();
		}
        public IActionResult LeaderEdit()
        {
            return View();
        }
    }
}