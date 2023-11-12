using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class Activity
{
    public int ActivityId { get; set; }

    public int CategoryId { get; set; }

    public int MemberId { get; set; }

    public string ActivityName { get; set; } = null!;

    public string ActivityLocation { get; set; } = null!;

    public string ActivityCity { get; set; } = null!;

    public string ActivityArea { get; set; } = null!;

    public string ActivityNotes { get; set; } = null!;

    public int? CurrentPeople { get; set; }

    public int? MaxPeople { get; set; }

    public decimal JoinFee { get; set; }

    public string Payment { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime? DeadLine { get; set; }
}
