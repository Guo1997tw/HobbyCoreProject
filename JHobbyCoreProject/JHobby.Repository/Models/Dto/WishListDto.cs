using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class WishListDto
    {
        //活動狀態
        public string ActivityStatus { get; set; } = null!;

        public string ActivityName { get; set; } = null!;

        public int? CurrentPeople { get; set; }

        public int? MaxPeople { get; set; }
    }
}
