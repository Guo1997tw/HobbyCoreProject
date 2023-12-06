using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Implements;
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
        private readonly IMemberRepository _memberRepository;
        private readonly ISendMailService _sendMailService;
        private readonly IMapper _mapper;

        public MemberApiController(IMemberService memberService, IMapper mapper, ISendMailService sendMailService, IMemberRepository memberRepository)
        {
            _memberService = memberService;
            _mapper = mapper;
            _sendMailService = sendMailService;
            _memberRepository = memberRepository;
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

                // 快速會員
                var roleFast = member.Status == "0" ? "FastMember" : "NoFastMember";

                // 一般會員 (未填寫資料)
                var roleGeneral = member.Status == "1" ? "Member" : "NoMember";

                // 黑名單
                var roleBlack = member.Status == "2" ? "BlackMember" : "NoBlackMember";
                
                // 管理員
                var roleAdmin = member.Status == "99" ? "Admin" : "NoAdmin";

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, roleFast),
                    new Claim(ClaimTypes.Role, roleGeneral),
                    new Claim(ClaimTypes.Role, roleBlack),
                    new Claim(ClaimTypes.Role, roleAdmin),
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
    
    
		[HttpGet("{id}")]
		public ActionResult <MemberViewModel> GetMemberById(int id)     
		{
			var result = _memberService.GetByIdDetail(id);
			var done= new MemberViewModel
			{
				MemberId= result.MemberId,
				HashPassword = result.HashPassword,

			};
            return Ok(done);
		}


		[HttpPut("{id}")]
		public IActionResult UpdateMember(int id, [FromBody] UpdateMemberViewModel updateMemberViewModel)
		{
            if (id < 0) { return BadRequest(); }



            var result = new UpdateMemberModel
            {
               // Password = updateMemberViewModel.Password,
				NewPassword = updateMemberViewModel.NewPassword,
				OldPassword = updateMemberViewModel.OldPassword,
                PasswordTwo = updateMemberViewModel.PasswordTwo,
            };

            var done = _memberService.UpdateMember(id, result);       //會跑到Service層裡的方法

            return Ok(done);
        }
	}
}