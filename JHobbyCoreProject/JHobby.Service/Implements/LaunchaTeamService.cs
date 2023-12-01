using JHobby.Repository.Implements;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class LaunchaTeamService : ILaunchaTeamService
    {
        private readonly ILaunchaTeamRepository _LaunchaTeamRepostiory;
        private readonly ICommonService _iCommonService;
        public LaunchaTeamService(ILaunchaTeamRepository launchaTeamRepostiory, ICommonService commonService)
        {
            _LaunchaTeamRepostiory = launchaTeamRepostiory;
            _iCommonService = commonService;
        }



        public IEnumerable<LaunchaTeamModel> GetByIdOld(int id) 
        { 
       var result = _LaunchaTeamRepostiory.GetByIdOld(id);
        var queryResult = result.Select(a => new LaunchaTeamModel

        {
            MemberId = a.MemberId,
            ActivityName = a.ActivityName,
            CurrentPeople = a.CurrentPeople,
            ActivityStatus = a.ActivityStatus,
            StartTime = a.StartTime,
            IsCover = a.IsCover,
            ImageName = a.ImageName,
            ActivityImageId = a.ActivityImageId,
            DateConvert = _iCommonService.ConvertTime(a.StartTime).FirstOrDefault().DateConvert,
            TimeConvert = _iCommonService.ConvertTime(a.StartTime).FirstOrDefault().TimeConvert,
            CreatedDateConvert = _iCommonService.ConvertTime(a.Created).FirstOrDefault().DateConvert,
            CreatedTimeConvert = _iCommonService.ConvertTime(a.Created).FirstOrDefault().TimeConvert

        }); 

			return (IEnumerable<LaunchaTeamModel>)queryResult;
		}

}
}

