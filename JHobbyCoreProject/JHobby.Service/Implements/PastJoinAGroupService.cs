using Azure;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JHobby.Service.Implements
{
    public class PastJoinAGroupService : IPastJoinAGroupService
    {
        private readonly IPastJoinAGroupRepostiory _iPastJoinAGroupRepostiory;
        private readonly ICommonService _iCommonService;

        public PastJoinAGroupService(IPastJoinAGroupRepostiory iPastJoinAGroupRepostiory, ICommonService iCommonService)
        {
            _iPastJoinAGroupRepostiory = iPastJoinAGroupRepostiory;
            _iCommonService = iCommonService;
        }

        public IEnumerable<PastJoinAGroupModel> GetAll()
        {
            return _iPastJoinAGroupRepostiory.GetAll().Select(r => new PastJoinAGroupModel
            {
                ActivityId = r.ActivityId,
                MemberId = r.MemberId,
                ActivityName = r.ActivityName,
                ActivityStatus = _iCommonService.ConvertActivityStatus(r.ActivityStatus),
                ActivityCity = r.ActivityCity,
                CurrentPeople = r.CurrentPeople,
                StartTime = r.StartTime,
                NickName = r.NickName,
            });
        }

        public IQueryable<PastJoinAGroupModel> GetPastJoinAGroupsList(int page,int pageSize)
        {
            var result = _iPastJoinAGroupRepostiory.GetPastJoinAGroupAll(page,pageSize);

            var pastJoinAGroupModel = result.Select(r => new PastJoinAGroupModel
            {
                ActivityId = r.ActivityId,
                MemberId = r.MemberId,
                ActivityName = r.ActivityName,
                ActivityStatus = _iCommonService.ConvertActivityStatus(r.ActivityStatus),
                ActivityCity = r.ActivityCity,
                CurrentPeople = r.CurrentPeople,
                StartTime = r.StartTime,
                NickName = r.NickName,
            });

            return pastJoinAGroupModel;
        }
    }
}
