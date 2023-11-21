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
		public IActionResult Profile(int id)
        {
			ViewData["Title"] = "團主介紹";

            return View(new ProfileViewModel());
        }
		public IActionResult Test(int id)   //測試
		{
			return View(new ProfileViewModel
			{
				MemberId = id,
			});
		}
		public IEnumerable<ProfileViewModel> GetProfileById(int id)
		{
			var servicesDto = _profileService.GetProfileById(id);
			var viewModel = new ProfileViewModel
			{
				MemberId = servicesDto.MemberId,
				NickName = servicesDto.NickName,
				Gender = servicesDto.Gender,
				AcitveCity = servicesDto.AcitveCity,
				PersonalProfile = servicesDto.PersonalProfile,
			};
			yield return viewModel;

		}

	}
}
