using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class InputScoreDto
    {
        public int MemberId { get; set; }

        public int ActivityId { get; set; }

        public int? Fraction { get; set; }

        public DateTime EvaluationTime { get; set; }
    }
}
