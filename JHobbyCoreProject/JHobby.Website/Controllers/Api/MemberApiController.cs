using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                Password = memberRegisterViewModel.Password,
                Status = memberRegisterViewModel.Status,
                CreationDate = memberRegisterViewModel.CreationDate
            };

            _memberService.CreateMemberRegister(mapper);

            return Ok(mapper);
        }

        [HttpPost]
        public IActionResult CheckMember(MemberLoginViewModel memberLoginViewModel)
        {
            if(_memberService.CheckMemberLogin(memberLoginViewModel.Account, memberLoginViewModel.Password))
            {
                return Ok(new { Message = "登入成功~~" });
            }

            return Unauthorized(new { Message = "登入失敗!!" });
        }
    }
}