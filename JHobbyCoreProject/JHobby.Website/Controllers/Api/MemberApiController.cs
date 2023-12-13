using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MemberApiController(IMemberService memberService, IMapper mapper,
                                   ISendMailService sendMailService,
                                   IMemberRepository memberRepository,
								   IWebHostEnvironment webHostEnvironment)
        {
            _memberService = memberService;
            _mapper = mapper;
            _sendMailService = sendMailService;
            _memberRepository = memberRepository;
			_webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public bool CheckAccountStatus(string account)
        {
            return _memberService.CheckAccountIsRepeat(account);
        }

        [HttpPost]
        public bool InsertRegister(MemberRegisterViewModel memberRegisterViewModel)
        {
            string _path = _webHostEnvironment.WebRootPath;
            if (!(_memberService.CheckAccountIsRepeat(memberRegisterViewModel.Account)))
            {
                return false;
            }

            var mapper = new MemberRegisterModel
            {
                Account = memberRegisterViewModel.Account,
                HashPassword = memberRegisterViewModel.HashPassword,
                Status = memberRegisterViewModel.Status,
                CreationDate = memberRegisterViewModel.CreationDate
            };

            if (_memberService.CreateMemberRegister(mapper))
            {
                _sendMailService.SendLetter(_path, memberRegisterViewModel.Account);

                return true;
            }

            return false;
        }

        [HttpPost]
        public bool CheckMember(MemberLoginViewModel memberLoginViewModel)
        {
            if (_memberService.CheckMemberLogin(memberLoginViewModel.Account, memberLoginViewModel.HashPassword))
            {
                var member = _memberService.MemberStatus(memberLoginViewModel.Account);

                var roleAll = member.Status switch
                {
                    "0" => "FastMember",
                    "1" => "Member",
                    "8" => "NoVerify",
                    "99" => "Admin",
                    _ => "NoMember"
                };

                //// 快速會員
                //var roleFast = member.Status == "0" ? "FastMember" : "NoFastMember";

                //// 一般會員 (未填寫資料)
                //var roleGeneral = member.Status == "1" ? "Member" : "NoMember";

                //// 管理員
                //var roleAdmin = member.Status == "99" ? "Admin" : "NoAdmin";

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, $"{ member.MemberId }"),
                    new Claim(ClaimTypes.Role, roleAll),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60) }
                );

                return true;
            }

            return false;
        }

        [HttpPost("{account}")]
        public bool UseResetPwd(MemberResetViewModel memberResetViewModel)
        {
            string _path = _webHostEnvironment.WebRootPath;
			var mapper = _mapper.Map<MemberResetModel>(memberResetViewModel);

            var result = _memberService.ResetPwd(_path,mapper);

            if (result == false) { return false; }

            return true;
        }

        [HttpGet]
        public IActionResult GetStatus(string account)
        {
            var queryResult = _memberService.MemberStatus(account);

            var mapper = _mapper.Map<MemberStatusViewModel>(queryResult);

            return Ok(mapper);
        }


        [HttpGet("{id}")]
        public ActionResult<MemberViewModel> GetMemberById(int id)
        {
            var result = _memberService.GetByIdDetail(id);
            var done = new MemberViewModel
            {
                MemberId = result.MemberId,
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

        [HttpPost]
        public bool reSendVerifyMail([FromForm] ReSendVerifyMailViewModel reSendVerifyMailViewModel)
        {
            string _path = _webHostEnvironment.WebRootPath;
            var result = _sendMailService.SendLetter(_path, reSendVerifyMailViewModel.Account);
            if (result)
            {
                return true;
            }
            return false;
        }
    }
}