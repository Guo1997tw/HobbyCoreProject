using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
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
		public IActionResult MemberProfile(int id)
        {
			ViewData["Title"] = "會員個人介紹";

			return View(new ProfileTestViewModel
			{
				MemberId = id
			});
		}
	}
}
