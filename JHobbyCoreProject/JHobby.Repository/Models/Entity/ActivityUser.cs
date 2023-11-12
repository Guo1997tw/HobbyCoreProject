using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class ActivityUser
{
    public int ActivityUserId { get; set; }

    public int MemberId { get; set; }

    public int ActivityId { get; set; }

    public string ReviewStatus { get; set; } = null!;
}
