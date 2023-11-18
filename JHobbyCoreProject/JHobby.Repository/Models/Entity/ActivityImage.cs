using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class ActivityImage
{
    public int ActivityImageId { get; set; }

    public int ActivityId { get; set; }

    public string ImageName { get; set; } = null!;

    public bool IsCover { get; set; }

    public DateTime UploadTime { get; set; }

    public virtual Activity Activity { get; set; } = null!;
}
