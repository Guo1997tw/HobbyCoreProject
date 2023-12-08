using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class VerifyModel
    {
        public string Account { get; set; } = null!;
        public bool Success { get; set; }
    }
}
