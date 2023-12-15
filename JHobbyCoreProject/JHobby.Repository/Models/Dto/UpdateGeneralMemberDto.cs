using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class UpdateGeneralMemberDto
    {
        public string? HeadShot { get; set; }

        public string? NickName { get; set; }

        public string? ActiveCity { get; set; }

        public string? ActiveArea { get; set; }

        public string? Address { get; set; }

        public string? PersonalProfile { get; set; }
    }
}
