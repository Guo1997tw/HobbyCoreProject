﻿namespace JHobby.Website.Models.ViewModels
{
    public class MemberMsgViewModel
    {
        public string? HeadShot { get; set; }

        public DateTime MessageTime { get; set; }

        public string? NickName { get; set; }

        public string MessageText { get; set; } = null!;
    }
}