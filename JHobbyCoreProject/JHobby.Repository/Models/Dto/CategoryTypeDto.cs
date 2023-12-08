using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class CategoryTypeDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public List<CategoryDetailDto> CategoryDetails { get; set; } = new List<CategoryDetailDto>();
    }
}