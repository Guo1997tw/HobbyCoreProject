using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class CategoryDetailModel
    {
        public int CategoryTypeId { get; set; }

        public int CategoryId { get; set; }

        public string TypeName { get; set; } = null!;
    }
}