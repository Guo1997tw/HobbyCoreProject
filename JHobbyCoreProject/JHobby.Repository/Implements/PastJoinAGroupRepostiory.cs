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
    internal class PastJoinAGroupRepostiory : IPastJoinAGroupRepostiory
    {
        private readonly JhobbyContext _JhobbyContext;

        public PastJoinAGroupRepostiory(JhobbyContext jhobbyContext)
        {
            
            _JhobbyContext = jhobbyContext;
        }


        public IEnumerable<PastJoinAGroupDto> GetPastJoinAGroupAll()
        {
            var queryResult = _JhobbyContext.Activities.Join(
                _JhobbyContext.Members,
                a => a.MemberId,
                m => m.MemberId,
                (a,m) => new PastJoinAGroupDto
                {
                    ActivityId = a.ActivityId,
                    MemberId = a.MemberId,
                    ActivityName = a.ActivityName,
                    ActivityStatus = a.ActivityStatus,
                    ActivityCity = a.ActivityCity,
                    CurrentPeople = a.CurrentPeople,
                    StartTime = a.StartTime,
                    NickName = m.NickName
                }).ToList();

            return queryResult;
        }
    }

}
