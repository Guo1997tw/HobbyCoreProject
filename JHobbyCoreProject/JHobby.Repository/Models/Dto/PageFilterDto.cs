using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class PageFilterDto<T>
    {
        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
