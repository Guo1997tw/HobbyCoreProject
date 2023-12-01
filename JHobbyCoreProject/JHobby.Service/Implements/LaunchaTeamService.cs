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

        public LaunchaTeamService(ILaunchaTeamRepository launchaTeamRepostiory)
        {
            _LaunchaTeamRepostiory = launchaTeamRepostiory;
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

        }); 

			return (IEnumerable<LaunchaTeamModel>)queryResult;
		}

}
}

