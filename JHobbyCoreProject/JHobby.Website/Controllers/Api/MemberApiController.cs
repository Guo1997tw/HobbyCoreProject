using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Implements;
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
        private readonly IMemberRepository _memberRepository;

		public MemberApiController(IMemberService memberService, IMemberRepository memberRepository)
        {
            _memberService = memberService;
            _memberRepository = memberRepository;
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

		[HttpGet("{id}")]
		public ActionResult <MemberViewModel> GetMemberById(int id)     
		{
			var result = _memberService.GetByIdDetail(id);
			var done= new MemberViewModel
			{
				MemberId= result.MemberId,
                Password= result.Password,
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