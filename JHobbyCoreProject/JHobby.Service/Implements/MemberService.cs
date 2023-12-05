using JHobby.Repository.Implements;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ISendMailService _sendMailService;

        public MemberService(IMemberRepository memberRepository, IMapper mapper, ISendMailService sendMailService)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _sendMailService = sendMailService;
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

        public MemberModel GetByIdDetail(int id)
        {
            var resultA = _memberRepository.GetById(id);
            if (resultA == null) return null;

            return new MemberModel
            {
                MemberId = resultA.MemberId,
				HashPassword = resultA.HashPassword,

			};

        }

        public bool UpdateMember(int id, UpdateMemberModel updateMemberModel)       
        {
			var resultA = _memberRepository.GetById(id);
			if (resultA == null) { return false; }

			var salt = resultA.SaltPassword;
            var hashPwd = HashPwdWithHMACSHA256(updateMemberModel.NewPassword, salt);
          

            var saltTwo = resultA.SaltPassword;
            var hashPwdTwo = HashPwdWithHMACSHA256(updateMemberModel.OldPassword, saltTwo);
          

            var databasePassword = resultA.HashPassword;         // 假設從資料庫中取得的密碼是 resultA.HashPassword      
          

            if (hashPwdTwo == databasePassword && hashPwdTwo != hashPwd && updateMemberModel.PasswordTwo == updateMemberModel.NewPassword)
            {
                var target = new UpdateMemberDto
                {
                    NewPassword = hashPwd,
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

            if (queryResult != null)
            {
                var hashTemp = queryResult.HashPassword;
                var saltTemp = queryResult.SaltPassword;
                var hashPwd = HashPwdWithHMACSHA256(password, saltTemp);

                return hashPwd == hashTemp;
            }

            return false;
        }

        public bool ResetPwd(MemberResetModel memberResetModel)
        {
            var newPwd = RandomPwd();
            var salt = RandomSalt();
            var hashPwd = HashPwdWithHMACSHA256(newPwd, salt);

            var mapper = _mapper.Map<MemberResetDto>(memberResetModel);

            mapper.HashPassword = hashPwd;
            mapper.SaltPassword = salt;

            var execute = _memberRepository.ResetByIdAndNewInsert(mapper);

            _sendMailService.ResetPwdSendLetter(memberResetModel.Account, newPwd);

            if (execute == false) { return false; }

            return true;
        }

        public MemberStatusModel MemberStatus(string account)
        {
            var queryResult = _memberRepository.GetMemberStatus(account);

            var mapper = _mapper.Map<MemberStatusModel>(queryResult);

            return mapper;
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

        private string RandomPwd(int minNum = 6, int maxNum = 12)
        {
            int size = RandomNumberSize(minNum, maxNum);

            const string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_~";

            StringBuilder stringBuilder = new StringBuilder(size);

            byte[] intBytes = new byte[4];

            for(int i = 0; i < size; i++)
            {
                RandomNumberGenerator.Fill(intBytes);

                uint num = BitConverter.ToUInt32(intBytes, 0);

                stringBuilder.Append(chars[(int)(num % (uint)chars.Length)]);
            }

            return stringBuilder.ToString();
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