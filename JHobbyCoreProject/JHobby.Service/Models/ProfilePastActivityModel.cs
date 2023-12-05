using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class ProfilePastActivityModel
    {
        public int MemberId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; } = null!;
        public string ActivityStatus { get; set; } = null!;
        public bool IsCover { get; set; }
        public string ImageName { get; set; } = null!;
        public int ActivityImageId { get; set; }
        public string ActivityCity { get; set; } = null!;
        public string? ActivityNotes { get; set; }
        public DateTime StartTime { get; set; }
        public string? DateConvert { get; set; }
        public string? TimeConvert { get; set; }
        public int CategoryId { get; set; }
        public int CategoryTypeId { get; set; }
    }
}
