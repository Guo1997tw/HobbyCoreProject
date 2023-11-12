using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class Wish
{
    public int WishId { get; set; }

    public int MemberId { get; set; }

    public int ActivityId { get; set; }

    public DateTime AddTime { get; set; }
}
