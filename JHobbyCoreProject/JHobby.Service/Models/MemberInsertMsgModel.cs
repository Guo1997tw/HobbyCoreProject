using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class MemberInsertMsgModel
    {
        public int MemberId { get; set; }

        public int ActivityId { get; set; }

        public DateTime MessageTime { get; set; }

        public string MessageText { get; set; } = null!;
    }
}