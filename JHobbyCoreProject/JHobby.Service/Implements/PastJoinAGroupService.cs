using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    internal class PastJoinAGroupService : IPastJoinAGroupService
    {
        private readonly IPastJoinAGroupRepostiory _iPastJoinAGroupRepostiory;

        public PastJoinAGroupService(IPastJoinAGroupRepostiory iPastJoinAGroupRepostiory)
        {
            _iPastJoinAGroupRepostiory = iPastJoinAGroupRepostiory;
        }

        public IEnumerable<PastJoinAGroupModel> GetPastJoinAGroupsList()
        {
            var result = _iPastJoinAGroupRepostiory.GetPastJoinAGroupAll();

            var pastJoinAGroupModel = result.Select(r => new PastJoinAGroupModel
            {
                ActivityId = r.ActivityId,
                MemberId = r.MemberId,
                ActivityName = r.ActivityName,
                ActivityStatus = r.ActivityStatus,
                ActivityCity = r.ActivityCity,
                CurrentPeople = r.CurrentPeople,
                StartTime = r.StartTime,
                NickName = r.NickName,
            });

            return pastJoinAGroupModel;
        }
    }
}
