﻿using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    [Authorize(Roles = "Member, FastMember,Admin")]
    public class ReviewController : Controller
	{
		private readonly IUserAuthenticationService _userAuthenticationService;
		public ReviewController(IUserAuthenticationService userAuthenticationService)
		{
			_userAuthenticationService = userAuthenticationService;
		}
		public IActionResult Apply()
		{
			ViewData["Title"] = "報名審核";
            ViewBag.VerifyMemberId = _userAuthenticationService.GetUserId();
            return View();
            
		}
	}
}
