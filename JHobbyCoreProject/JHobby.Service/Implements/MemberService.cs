using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public bool CreateMemberRegister(MemberRegisterModel memberRegisterModel)
        {
            var mapper = new MemberRegisterDto
            {
                Account = memberRegisterModel.Account,
                Password = memberRegisterModel.Password,
                Status = memberRegisterModel.Status,
                CreationDate = memberRegisterModel.CreationDate,
            };

            _memberRepository.InsertMemberRegister(mapper);
            
            return true;
        }
    }
}