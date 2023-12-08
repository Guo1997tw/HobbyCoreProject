using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace JHobby.Website.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ResetPwdToMail()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Member");
        }
        [HttpGet]
        [Route("/{controller}/{action}/{verify}")]
        public IActionResult VerifyMail(string verify)
        {
            try
            {
                ViewBag.message = "驗證失敗，請點選下方重送驗證信";
                var Model = _memberService.CheckVerify(verify);
                var viewModel = new VerifyViewModel
                {
                    Account = Model.Account,
                    Success = Model.Success,
                };
                if (viewModel.Success)
                {
                    ViewBag.message = "恭喜驗證成功，請點選下方返回首頁重新登入";
                }
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("NotFounds", "ErrorPage");
            }
           
        }
    }
}