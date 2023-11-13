using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class ActivityImage
{
    public int Id { get; set; }

    public int ActivityId { get; set; }

    public string ActivityImage1 { get; set; } = null!;

    public bool IsCover { get; set; }

    public DateTime UploadTime { get; set; }

    public virtual Activity Activity { get; set; } = null!;
}
