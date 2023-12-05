using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class CategoryTypeModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public IEnumerable<CategoryDetailModel> CategoryDetails { get; set; } = new List<CategoryDetailModel>();
    }
}