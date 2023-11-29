using JHobby.Repository.Implements;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Identity.Client;
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

            _memberRepository.InsertMemberRegister(mapper);

            return true;
        }


        public MemberModel GetByIdDetail(int id)
        {
            var resultA = _memberRepository.GetById(id);
            if (resultA == null) return null;

            return new MemberModel
            {
                MemberId = resultA.MemberId,
                Password = resultA.Password,
            };

        }


        public bool UpdateMember(int id, UpdateMemberModel updateMemberModel)
        {
            var salt = RandomSalt();
            var hashPwd = HashPwdWithHMACSHA256(updateMemberModel.NewPassword, salt);
            var pwdSalt = $"{hashPwd}:{salt}";

			var saltTwo = RandomSalt();
			var hashPwdTwo = HashPwdWithHMACSHA256(updateMemberModel.OldPassword, saltTwo);
			var pwdSaltTwo = $"{hashPwdTwo}:{salt}";


			var resultA = _memberRepository.GetById(id);            
            if (resultA == null) { return false; }
             
            var databasePassword = resultA.Password;         // 假設從資料庫中取得的密碼是 resultA.Password      

            updateMemberModel.OldPassword = pwdSaltTwo;           


			if (updateMemberModel.OldPassword == databasePassword && updateMemberModel.OldPassword != updateMemberModel.NewPassword && updateMemberModel.PasswordTwo == updateMemberModel.NewPassword)
            {
                var target = new UpdateMemberDto
                {       
                    NewPassword = pwdSalt,
                };

                _memberRepository.Update(id, target);

                return true;
            }

            else
            {
                return false;
            }
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