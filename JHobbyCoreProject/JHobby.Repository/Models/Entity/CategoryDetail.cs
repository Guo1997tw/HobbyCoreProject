using System;
using System.Collections.Generic;

namespace JHobby.Repository.Models.Entity;

public partial class CategoryDetail
{
    public int CategoryTypeId { get; set; }

    public int CategoryId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
