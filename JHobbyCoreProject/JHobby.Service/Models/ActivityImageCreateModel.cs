using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class ActivityImageCreateModel
    {
        public int BuildId { get; set; }

        public string ImageName { get; set; } = null!;

        public bool IsCover { get; set; } = false;

        public DateTime UploadTime { get; set; } = DateTime.Now;

    }
}