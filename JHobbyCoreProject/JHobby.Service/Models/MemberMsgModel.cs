using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class MemberMsgModel
    {
        public int MemberId { get; set; }
        public int ActivityId { get; set; }

        public string? HeadShot { get; set; }

        public string? MessageDate { get; set; }

        public string? MessageTime { get; set; }

        public string? NickName { get; set; }

        public string MessageText { get; set; } = null!;
    }
}