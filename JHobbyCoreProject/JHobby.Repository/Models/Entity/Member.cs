using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class Member
{
    public int MemberId { get; set; }

    public string? MemberName { get; set; }

    public string? NickName { get; set; }

    public string? Gender { get; set; }

    public string Account { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string SaltPassword { get; set; } = null!;

    public string? IdentityCard { get; set; }

    public DateTime? Birthday { get; set; }

    public string? ActiveCity { get; set; }

    public string? ActiveArea { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? HeadShot { get; set; }

    public string? PersonalProfile { get; set; }

    public string Status { get; set; } = null!;

    public string? OnlineStatus { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastSignIn { get; set; }

    public virtual ICollection<ActivityUser> ActivityUsers { get; set; } = new List<ActivityUser>();

    public virtual ICollection<MsgBoard> MsgBoards { get; set; } = new List<MsgBoard>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual ICollection<Wish> Wishes { get; set; } = new List<Wish>();
}
