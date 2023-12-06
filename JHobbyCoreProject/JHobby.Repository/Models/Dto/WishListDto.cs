using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class WishListDto
    {
        public int WishId { get; set; }

        //活動狀態
        public string ActivityStatus { get; set; } = null!;

        public string ActivityName { get; set; } = null!;

        public int ActivityId { get; set; }

        public int MemberId { get; set; }

        public int? CurrentPeople { get; set; }

        public int? MaxPeople { get; set; }

        public string ImageName { get; set; } = null!;
    }
}
