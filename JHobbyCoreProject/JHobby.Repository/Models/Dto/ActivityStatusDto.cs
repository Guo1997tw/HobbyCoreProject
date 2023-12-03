using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class ActivityStatusDto
    {
        public int ActivityId { get; set; }
        public string ActivityStatus { get; set; } = null!;
    }
}
