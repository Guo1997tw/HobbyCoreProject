using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ProfileController : Controller
    {
		private readonly IProfileService _profileService;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public ProfileController(IProfileService profileService, IUserAuthenticationService userAuthenticationService)
		{
			_profileService = profileService;
            _userAuthenticationService = userAuthenticationService;
        }

        [Authorize(Roles = "Member")]
        public IActionResult MemberProfile(int id)
        {
            var view = new ProfileTestViewModel();

            

            ViewData["Title"] = "會員個人介紹";
			//try
			//{
                view.VerifyMemberId = _userAuthenticationService.GetUserId();
                view.MemberId = id;
   //         }
			//catch (Exception ex)
			//{

			//}
            return View(view);

        }
	}
}
