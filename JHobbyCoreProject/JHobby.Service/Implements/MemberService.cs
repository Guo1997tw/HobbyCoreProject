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
            var salt = RandomSalt();
            var hashPwd = HashPwdWithHMACSHA256(memberRegisterModel.Password, salt);
            var pwdSalt = $"{hashPwd}:{salt}";

            var mapper = new MemberRegisterDto
            {
                Account = memberRegisterModel.Account,              
                Password = pwdSalt,
                Status = memberRegisterModel.Status,
                CreationDate = memberRegisterModel.CreationDate,
            };

            return _memberRepository.InsertMemberRegister(mapper) ? true : false;
        }

        public bool CheckMemberLogin(string account, string password)
        {
            var queryResult = _memberRepository.GetMemberLogin(account);

            if(queryResult != null)
            {
                var parts = queryResult.Password.Split(':');

                if (parts.Length != 2) { return false; }

                var saveHash = parts[0];
                var saveSalt = parts[1];

                var hashPwd = HashPwdWithHMACSHA256(password, saveSalt);

                return hashPwd == saveHash;
            }

            return false;
        }

        private string RandomSalt(int size = 32)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[size];

                rng.GetBytes(buffer);

                return Convert.ToBase64String(buffer);
            }
        }

        private string HashPwdWithHMACSHA256(string password, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var hmac = new HMACSHA256(saltBytes))
            {
                var pwdBytes = Encoding.UTF8.GetBytes(password);
                var hash = hmac.ComputeHash(pwdBytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}