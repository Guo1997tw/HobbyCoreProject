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

        public IEnumerable<PastJoinAGroupModel> GetPastJoinAGroupAll()
        {
            return _iPastJoinAGroupRepostiory.GetPastJoinAGroupAll().Select(r => new PastJoinAGroupModel
            {
                ActivityId = r.ActivityId,
                ActivityName = r.ActivityName,
                ActivityStatus = _iCommonService.ConvertActivityStatus(r.ActivityStatus),
                ActivityCity = r.ActivityCity,
                CurrentPeople = r.CurrentPeople,
                NickName = r.NickName,

                //將StartTime轉成日期格式和時間格式
                DateConvert = _iCommonService.ConvertTime(r.StartTime).FirstOrDefault().DateConvert,
                TimeConvert = _iCommonService.ConvertTime(r.StartTime).FirstOrDefault().TimeConvert
            }) ;
        }

        //public IEnumerable<PastJoinAGroupModel> GetPastJoinAGroupById(int memberId)
        //{
        //    return _iPastJoinAGroupRepostiory.GetPastJoinAGroupById(memberId).Select(r => new PastJoinAGroupModel
        //    {
        //        ActivityId = r.ActivityId,
        //        ActivityName = r.ActivityName,
        //        ActivityStatus = _iCommonService.ConvertActivityStatus(r.ActivityStatus),
        //        ActivityCity = r.ActivityCity,
        //        CurrentPeople = r.CurrentPeople,
        //        NickName = r.NickName,
        //        MemberId = r.MemberId,
        //        Fraction = r.Fraction,

        //        //將StartTime轉成日期格式和時間格式
        //        DateConvert = _iCommonService.ConvertTime(r.StartTime).FirstOrDefault().DateConvert,
        //        TimeConvert = _iCommonService.ConvertTime(r.StartTime).FirstOrDefault().TimeConvert,

        //        ImageName = r.ImageName,
        //    });
        //}

        public PageFilterDto<PastJoinAGroupModel> GetPastJoinAGroupById(int memberId, int pageNumber, int pageSize)
        {
            var queryResult = _iPastJoinAGroupRepostiory.GetPastJoinAGroupById(memberId, pageNumber, pageSize);
            return new PageFilterDto<PastJoinAGroupModel>
            {
                PageNumber = queryResult.PageNumber,
                TotalPages = queryResult.TotalPages,
                Items = queryResult.Items.Select(r => new PastJoinAGroupModel
                {
                    ActivityId = r.ActivityId,
                    ActivityName = r.ActivityName,
                    ActivityStatus = _iCommonService.ConvertActivityStatus(r.ActivityStatus),
                    ActivityCity = r.ActivityCity,
                    CurrentPeople = r.CurrentPeople,
                    NickName = r.NickName,
                    MemberId = r.MemberId,
                    Fraction = r.Fraction,

                    //將StartTime轉成日期格式和時間格式
                    DateConvert = _iCommonService.ConvertTime(r.StartTime).FirstOrDefault().DateConvert,
                    TimeConvert = _iCommonService.ConvertTime(r.StartTime).FirstOrDefault().TimeConvert,

                    ImageName = r.ImageName,
                })
            };
        }
    }
}
