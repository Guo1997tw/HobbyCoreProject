using AutoMapper;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MemberApiController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberApiController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public IActionResult InsertRegister(MemberRegisterViewModel memberRegisterViewModel)
        {
            var mapper = new MemberRegisterModel
            {
                Account = memberRegisterViewModel.Account,
                HashPassword = memberRegisterViewModel.HashPassword,
                Status = memberRegisterViewModel.Status,
                CreationDate = memberRegisterViewModel.CreationDate
            };

            _memberService.CreateMemberRegister(mapper);

            return Ok(mapper);
        }

        [HttpPost]
        public IActionResult CheckMember(MemberLoginViewModel memberLoginViewModel)
        {
            if (_memberService.CheckMemberLogin(memberLoginViewModel.Account, memberLoginViewModel.HashPassword))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, memberLoginViewModel.Account),
                    new Claim(ClaimTypes.Role, "0")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60) }
                );

                return Ok(new { Message = "登入成功~~" });
            }

            return Unauthorized(new { Message = "登入失敗!!" });

            //if(_memberService.CheckMemberLogin(memberLoginViewModel.Account, memberLoginViewModel.HashPassword))
            //{
            //    return Ok(new { Message = "登入成功~~" });
            //}

            //return Unauthorized(new { Message = "登入失敗!!" });
        }
    }
}