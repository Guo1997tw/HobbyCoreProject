using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class PageFilterModel<T>
    {
        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
