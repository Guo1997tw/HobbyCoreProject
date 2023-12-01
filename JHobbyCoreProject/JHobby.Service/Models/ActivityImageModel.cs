using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class ActivityImageModel
    {
        public int ActivityImageId { get; set; }

        public int AiActivity { get; set; }

        public string ImageName { get; set; } = null!;

        public bool IsCover { get; set; }

        public DateTime UploadTime { get; set; }
    }
}