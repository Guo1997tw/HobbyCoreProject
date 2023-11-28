using JHobby.Repository.Interfaces;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class NowJoinAGroupService : INowJoinAGroupService
    {
        private readonly INowJoinAGroupRepository _nowJoinAGroupRepository;
        private readonly ICommonService _commonService;

        public NowJoinAGroupService(INowJoinAGroupRepository nowJoinAGroupRepository,ICommonService commonService)

        {
            _nowJoinAGroupRepository = nowJoinAGroupRepository;
            _commonService = commonService;
        }

        public IEnumerable<NowJoinAGroupModel> GetNowJoinAGroupAll()
        {
            return _nowJoinAGroupRepository.GetNowJoinAGroupAll()
                .Select(s => new NowJoinAGroupModel
                {
                    ActivityUserId = s.ActivityUserId,
                    ActivityId = s.ActivityId,
                    MemberId = s.MemberId,
                    ActivityName = s.ActivityName,
                    ReviewStatus = _commonService.ConvertReviewStatus(s.ReviewStatus),
                    ReviewTime = s.ReviewTime,
                    CurrentPeople = s.CurrentPeople,
                    MaxPeople = s.MaxPeople,
                    NickName = s.NickName,
                    StartTime = s.StartTime,
                });
        }
    }
}
