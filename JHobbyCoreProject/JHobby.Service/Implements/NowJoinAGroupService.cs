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
    public class NowJoinAGroupService : INowJoinAGroupService
    {
        private readonly INowJoinAGroupRepository _nowJoinAGroupRepository;
        private readonly ICommonService _iCommonService;

        public NowJoinAGroupService(INowJoinAGroupRepository nowJoinAGroupRepository,ICommonService commonService)

        {
            _nowJoinAGroupRepository = nowJoinAGroupRepository;
            _iCommonService = commonService;
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
                    ReviewStatus = _iCommonService.ConvertReviewStatus(s.ReviewStatus),
                    ReviewTime = s.ReviewTime,
                    CurrentPeople = s.CurrentPeople,
                    MaxPeople = s.MaxPeople,
                    NickName = s.NickName,
                    DateConvert = _iCommonService.ConvertTime(s.StartTime).First().DateConvert,
                    TimeConvert = _iCommonService.ConvertTime(s.StartTime).First().TimeConvert
                });
        }

        public IEnumerable<NowJoinAGroupModel> GetNowJoinAGroupById(int memberId)
        {
            return _nowJoinAGroupRepository.GetNowJoinAGroupById(memberId)
                .Select(s => new NowJoinAGroupModel
                {
                    ActivityName = s.ActivityName,
                    ActivityUserId = s.ActivityUserId,
                    MemberId = s.MemberId,
                    ReviewStatus = _iCommonService.ConvertReviewStatus(s.ReviewStatus),
                    CurrentPeople = s.CurrentPeople,
                    MaxPeople = s.MaxPeople,
                    NickName = s.NickName,
                    DateConvert = _iCommonService.ConvertTime(s.StartTime).First().DateConvert,
                    TimeConvert = _iCommonService.ConvertTime(s.StartTime).First().TimeConvert
                });
        }

        public bool NowJoinAGroupCancel(int activityUserId, int memberId, NowJoinAGroupCancelModel nowJoinAGroupCancel)
        {
            var mapping = new NowJoinAGroupCancelDto
            {
                ReviewStatus = nowJoinAGroupCancel.ReviewStatus,
            };
            _nowJoinAGroupRepository.NowJoinAGroupCancel(activityUserId, memberId, mapping);

            return true;
        }
    }
}
