using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class MemberMsgDto
    {
        public int ActivityId { get; set; }

        public string? HeadShot { get; set; }

        public DateTime MessageTime { get; set; }

        public string? NickName { get; set; }

        public string MessageText { get; set; } = null!;
    }
}