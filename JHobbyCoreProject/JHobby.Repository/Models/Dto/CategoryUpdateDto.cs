using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class CategoryUpdateDto
    {
        public string CategoryName { get; set; } = null!;

        public string TypeName { get; set; } = null!;
    }
}