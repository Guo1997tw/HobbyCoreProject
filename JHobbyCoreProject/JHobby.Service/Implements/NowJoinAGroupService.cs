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
                    CurrentPeople = s.CurrentPeople,
                    MaxPeople = s.MaxPeople,
                    NickName = s.NickName,
                    DateConvert = _iCommonService.ConvertTime(s.StartTime).First().DateConvert,
                    TimeConvert = _iCommonService.ConvertTime(s.StartTime).First().TimeConvert
                });
        }

        public PageFilterDto<NowJoinAGroupModel> GetNowJoinAGroupById(int memberId, int pageNumber, int pageSize)
        {
            var queryResult = _nowJoinAGroupRepository.GetNowJoinAGroupById(memberId, pageNumber, pageSize);

            return new PageFilterDto<NowJoinAGroupModel>
            {
                PageNumber = queryResult.PageNumber,
                TotalPages = queryResult.TotalPages,
                Items = queryResult.Items.Select(s => new NowJoinAGroupModel
                {
                    ActivityName = s.ActivityName,
                    ActivityUserId = s.ActivityUserId,
                    ActivityId = s.ActivityId,
                    MemberId = s.MemberId,
                    ReviewStatus = _iCommonService.ConvertReviewStatus(s.ReviewStatus),
                    CurrentPeople = s.CurrentPeople,
                    MaxPeople = s.MaxPeople,
                    NickName = s.NickName,
                    DateConvert = _iCommonService.ConvertTime(s.StartTime).First().DateConvert,
                    TimeConvert = _iCommonService.ConvertTime(s.StartTime).First().TimeConvert,
                    ImageName = s.ImageName,
                })
            };
        }

        public bool NowJoinAGroupCancel(int activityId, int memberId, NowJoinAGroupCancelModel nowJoinAGroupCancel)
        {
            var mapping = new NowJoinAGroupCancelDto
            {
                ReviewStatus = nowJoinAGroupCancel.ReviewStatus,
            };
            _nowJoinAGroupRepository.NowJoinAGroupCancel(activityId, memberId, mapping);

            return true;
        }
    }
}
