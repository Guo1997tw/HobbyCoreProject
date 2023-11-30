﻿using Azure;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
    public class PastJoinAGroupRepostiory : IPastJoinAGroupRepostiory
    {
        private readonly JhobbyContext _JhobbyContext;

        public PastJoinAGroupRepostiory(JhobbyContext jhobbyContext)
        {

            _JhobbyContext = jhobbyContext;
        }

        public IEnumerable<PastJoinAGroupDto> GetPastJoinAGroupAll()
        {
            return _JhobbyContext.Activities.Join(
               _JhobbyContext.Members,
               a => a.MemberId,
               m => m.MemberId,
               (a, m) => new PastJoinAGroupDto
               {
                   ActivityId = a.ActivityId,
                   ActivityName = a.ActivityName,
                   ActivityStatus = a.ActivityStatus,
                   ActivityCity = a.ActivityCity,
                   CurrentPeople = a.CurrentPeople,
                   StartTime = a.StartTime,
                   NickName = m.NickName
               });
        }

        public IEnumerable<PastJoinAGroupDto> GetPastJoinAGroupById(int memberId)
        {
            return _JhobbyContext.Activities
                .Where(a => a.MemberId == memberId)
                .Join(_JhobbyContext.Members,
               a => a.MemberId,
               m => m.MemberId,
               (a, m) => new PastJoinAGroupDto
               {
                   ActivityId = a.ActivityId,
                   ActivityName = a.ActivityName,
                   ActivityStatus = a.ActivityStatus,
                   ActivityCity = a.ActivityCity,
                   CurrentPeople = a.CurrentPeople,
                   StartTime = a.StartTime,
                   NickName = m.NickName
               });
        }
    }

}
