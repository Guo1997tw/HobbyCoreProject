using Azure;
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

        public IEnumerable<PastJoinAGroupDto> GetAll()
        {
            return _JhobbyContext.Activities.Join(
               _JhobbyContext.Members,
               a => a.MemberId,
               m => m.MemberId,
               (a, m) => new PastJoinAGroupDto
               {
                   ActivityId = a.ActivityId,
                   MemberId = a.MemberId,
                   ActivityName = a.ActivityName,
                   ActivityStatus = a.ActivityStatus,
                   ActivityCity = a.ActivityCity,
                   CurrentPeople = a.CurrentPeople,
                   StartTime = a.StartTime,
                   NickName = m.NickName
               });
        }

        public IQueryable<PastJoinAGroupDto> GetPastJoinAGroupAll(int page, int pageSize)
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
                });

            return queryResult
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }

}
