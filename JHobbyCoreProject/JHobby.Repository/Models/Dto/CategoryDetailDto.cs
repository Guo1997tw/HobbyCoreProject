using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class CategoryDetailDto
    {
        public int CategoryTypeId { get; set; }

        public int CategoryId { get; set; }

        public string TypeName { get; set; } = null!;
    }
}