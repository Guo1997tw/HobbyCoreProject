﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Models
{
    public class MemberStatusModel
    {
        public int MemberId { get; set; }

        public string Account { get; set; } = null!;

        public string Status { get; set; } = null!;
    }
}