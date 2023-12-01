using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
    public interface IMemberService
    {
        public bool CreateMemberRegister(MemberRegisterModel memberRegisterModel);

        public bool CheckMemberLogin(string account, string password);

        public MemberStatusModel MemberStatus(string account);
    }
}