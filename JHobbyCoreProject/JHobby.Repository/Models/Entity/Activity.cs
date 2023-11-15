using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class Activity
{
    public int ActivityId { get; set; }

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

    public virtual ICollection<ActivityImage> ActivityImages { get; set; } = new List<ActivityImage>();

    public virtual ICollection<ActivityUser> ActivityUsers { get; set; } = new List<ActivityUser>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<MsgBoard> MsgBoards { get; set; } = new List<MsgBoard>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual ICollection<Wish> Wishes { get; set; } = new List<Wish>();
}
