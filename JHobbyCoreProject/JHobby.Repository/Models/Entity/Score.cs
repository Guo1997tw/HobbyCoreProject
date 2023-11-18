using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class Score
{
    public int ScoreId { get; set; }

    public int MemberId { get; set; }

    public int ActivityId { get; set; }

    public int? Fraction { get; set; }

    public DateTime EvaluationTime { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
