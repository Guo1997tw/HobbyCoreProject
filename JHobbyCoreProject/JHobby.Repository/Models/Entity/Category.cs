using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
