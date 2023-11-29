using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class MemberLoginDto
    {
        public string Account { get; set; } = null!;

        public string HashPassword { get; set; } = null!;
    }
}