using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class MemberStatusDto
    {
        public int MemberId { get; set; }

        public string Account { get; set; } = null!;

        public string NickName { get; set; } = null!;

        public string Status { get; set; } = null!;
    }
}