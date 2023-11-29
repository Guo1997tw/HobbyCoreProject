using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class MemberRegisterModel
    {
        public string Account { get; set; } = null!;

        public string HashPassword { get; set; } = null!;

        public string SaltPassword { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime CreationDate { get; set; }          
    }
}