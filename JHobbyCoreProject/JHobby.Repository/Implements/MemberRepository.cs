using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
    public class MemberRepository : IMemberRepository
    {
        private readonly JhobbyContext _jhobbyContext;

        public MemberRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext = jhobbyContext;
        }

        public bool InsertMemberRegister(MemberRegisterDto memberRegisterDto)
        {
            var mapper = new Member
            {
                Account = memberRegisterDto.Account,
                HashPassword = memberRegisterDto.HashPassword,
                SaltPassword = memberRegisterDto.SaltPassword,
                Status = memberRegisterDto.Status,
                CreationDate = memberRegisterDto.CreationDate,
            };

            _jhobbyContext.Members.Add(mapper); 
            _jhobbyContext.SaveChanges();

            return true;
        }

        public MemberLoginDto? GetMemberLogin(string account)
        {
            var queryResult = _jhobbyContext.Members.FirstOrDefault(x => x.Account == account);

            if (queryResult == null) { return null; }

            return new MemberLoginDto
            {
                Account = queryResult.Account,
                HashPassword = queryResult.HashPassword,
            };
        }
    }
}