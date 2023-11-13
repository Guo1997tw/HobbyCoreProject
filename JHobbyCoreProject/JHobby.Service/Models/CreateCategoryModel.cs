using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class CreateCategoryModel
    {
        public string CategoryName { get; set; } = null!;

        public string TypeName { get; set; } = null!;
    }
}