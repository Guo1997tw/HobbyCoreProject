using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Models.Dto
{
    public class UpdateProfileSettingDto
    {
        public string? UpdatedHeadShot { get; set; }
        public string? UpdatedNickName { get; set; }
        public string? UpdatedAcitveCity { get; set; }
        public string? UpdatedActiveArea { get; set; }
        public string? UpdatedAddress { get; set; }
        public string? UpdatedPhone { get; set; }
        public string? UpdatedPersonalProfile { get; set; }
    }
}
