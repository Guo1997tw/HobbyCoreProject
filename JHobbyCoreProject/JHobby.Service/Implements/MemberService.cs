using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            // 密碼加鹽十六進制
            byte[] bpwd = Encoding.Unicode.GetBytes(mapper.Password);

            HMACSHA256 hMACSHA256 = new HMACSHA256();

            byte[] hash = hMACSHA256.ComputeHash(bpwd);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }

            mapper.Password = sb.ToString();

            _memberRepository.InsertMemberRegister(mapper);
            
            return true;
        }

        public bool CheckMemberLogin(string account, string password)
        {
            var queryResult = _memberRepository.GetMemberLogin(account);

            if(queryResult != null)
            {
                return queryResult.Password == password;
            }

            return false;
        }
    }
}