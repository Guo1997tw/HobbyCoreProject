﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class ChangePasswordModel
    {
        public int MemberId { get; set; }
        public string Password { get; set; } = null!;
    }
}
