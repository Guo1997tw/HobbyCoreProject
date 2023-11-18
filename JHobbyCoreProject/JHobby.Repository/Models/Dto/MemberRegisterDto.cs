using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class MemberRegisterDto
    {
        public string Account { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime CreationDate { get; set; }
    }
}