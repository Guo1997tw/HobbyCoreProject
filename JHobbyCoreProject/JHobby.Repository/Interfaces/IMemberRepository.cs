using JHobby.Repository.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Interfaces
{
    public interface IMemberRepository
    {
        public bool InsertMemberRegister(MemberRegisterDto memberRegisterDto);

        public MemberLoginDto? GetMemberLogin(string account);

        public bool ResetByIdAndNewInsert(string account, MemberResetDto memberResetDto);

        public MemberStatusDto? GetMemberStatus(string account);

        public MemberDto? GetById(int id);

		public bool Update(int id,UpdateMemberDto updateMemberDto);
       
    }
}