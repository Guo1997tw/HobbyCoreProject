using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class ActivityCreateModel
    {
        public int MemberId { get; set; }

        public int CategoryId { get; set; }

        public int CategoryTypeId { get; set; }

        public string ActivityName { get; set; } = null!;

        public string ActivityStatus { get; set; } = null!;

        public string ActivityLocation { get; set; } = null!;

        public string ActivityCity { get; set; } = null!;

        public string ActivityArea { get; set; } = null!;

        public string? ActivityNotes { get; set; }

        public int? CurrentPeople { get; set; }

        public int? MaxPeople { get; set; }

        public string Payment { get; set; } = null!;

        public decimal JoinFee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime Created { get; set; }

        public DateTime JoinDeadLine { get; set; }

        public List<ActivityImageCreateModel> ActivityImages { get; set; }
    }
}
