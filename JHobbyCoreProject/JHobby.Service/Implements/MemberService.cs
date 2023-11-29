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
            var hashPwd = HashPwdWithHMACSHA256(memberRegisterModel.HashPassword, salt);

            var mapper = new MemberRegisterDto
            {
                Account = memberRegisterModel.Account,
                HashPassword = hashPwd,
                SaltPassword = salt,
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
                var parts = queryResult.HashPassword.Split(':');

                if (parts.Length != 2) { return false; }

                var saveHash = parts[0];
                var saveSalt = parts[1];

                var hashPwd = HashPwdWithHMACSHA256(password, saveSalt);

                return hashPwd == saveHash;
            }

            return false;
        }

        private int RandomNumberSize(int minNum, int maxNum)
        {
            byte[] intBytes = new byte[4];

            RandomNumberGenerator.Fill(intBytes);

            int randomInt = BitConverter.ToInt32(intBytes, 0);

            return Math.Abs(randomInt % (maxNum - minNum)) + minNum;
        }

        private string RandomSalt(int minNum = 8, int maxNum = 256)
        {
            int size = RandomNumberSize(minNum, maxNum);
            var buffer = new byte[size];

            RandomNumberGenerator.Fill(buffer);
            
            return Convert.ToBase64String(buffer);
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