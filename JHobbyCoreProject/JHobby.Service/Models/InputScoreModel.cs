using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class InputScoreModel
    {
        public int MemberId { get; set; }

        public int ActivityId { get; set; }

        public int? Fraction { get; set; }

        public DateTime EvaluationTime { get; set; }
    }
}
