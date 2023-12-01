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
        private readonly ISendMailService _sendMailService;
        private readonly IMapper _mapper;

        public MemberApiController(IMemberService memberService, IMapper mapper, ISendMailService sendMailService)
        {
            _memberService = memberService;
            _mapper = mapper;
            _sendMailService = sendMailService;
        }

        [HttpPost]
        public bool InsertRegister(MemberRegisterViewModel memberRegisterViewModel)
        {
            var mapper = new MemberRegisterModel
            {
                Account = memberRegisterViewModel.Account,
                HashPassword = memberRegisterViewModel.HashPassword,
                Status = memberRegisterViewModel.Status,
                CreationDate = memberRegisterViewModel.CreationDate
            };

            if(_memberService.CreateMemberRegister(mapper))
            {
                _sendMailService.SendLetter(memberRegisterViewModel.Account);
            }

            return true;
        }

        [HttpPost]
        public IActionResult CheckMember(MemberLoginViewModel memberLoginViewModel)
        {
            if (_memberService.CheckMemberLogin(memberLoginViewModel.Account, memberLoginViewModel.HashPassword))
            {
                var member = _memberService.MemberStatus(memberLoginViewModel.Account);

                var role = member.Status == "1" ? "Member" : "NoMember";

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, role)
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
        }

        [HttpGet]
        public IActionResult GetStatus(string account)
        {
            var queryResult = _memberService.MemberStatus(account);

            var mapper = _mapper.Map<MemberStatusViewModel>(queryResult);

            return Ok(mapper);
        }
    }
}