using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class MsgBoard
{
    public int MsgBoardId { get; set; }

    public int MemberId { get; set; }

    public int ActivityId { get; set; }

    public string MessageText { get; set; } = null!;

    public DateTime MessageTime { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
