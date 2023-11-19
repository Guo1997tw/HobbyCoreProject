using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ProfileController : Controller
    {
		private readonly IProfileService _profileService;
		public ProfileController(IProfileService profileService)
		{
			_profileService = profileService;
		}
		public IActionResult Profile()
        {
            ViewData["Title"] = "團主介紹";
            return View();
        }
  //      public IActionResult<ProfileViewModel> GetProfileById(int id)
		//{
        
  //      }

    }
}
