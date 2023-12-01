using AutoMapper;
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
        private readonly IMapper _mapper;

        public MemberRepository(JhobbyContext jhobbyContext, IMapper mapper)
        {
            _jhobbyContext = jhobbyContext;
            _mapper = mapper;
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
                SaltPassword = queryResult.SaltPassword,
            };
        }

        public MemberStatusDto? GetMemberStatus(string account)
        {
            var queryResult = _jhobbyContext.Members.FirstOrDefault(m => m.Account == account);

            var mapper = _mapper.Map<MemberStatusDto>(queryResult);

            return mapper;
        }
    }
}