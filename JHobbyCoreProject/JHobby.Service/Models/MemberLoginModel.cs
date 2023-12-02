using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class MemberLoginModel
    {
        public int MemberId { get; set; }

        public string Account { get; set; } = null!;

        public string HashPassword { get; set; } = null!;

        public string SaltPassword { get; set; } = null!;
    }
}