using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
    public class LaunchaTeamRepository : ILaunchaTeamRepository
    {
        private readonly JhobbyContext _jhobbyContext;

        public LaunchaTeamRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext = jhobbyContext;
        }

        public IEnumerable<LaunchaTeamDto> GetByIdOld(int id)
        {
            var result = _jhobbyContext.Activities.Join(
                   _jhobbyContext.ActivityImages,
                   a => a.ActivityId,
                   m => m.ActivityId,
                   (a, m) => new LaunchaTeamDto
                   {
                       MemberId = a.MemberId,
                       ActivityName = a.ActivityName,
                       CurrentPeople = a.CurrentPeople,
                       ActivityStatus = a.ActivityStatus,
                       StartTime = a.StartTime,
                       IsCover = m.IsCover,
                       ImageName = m.ImageName,
                       ActivityImageId = m.ActivityImageId,
                       Created = a.Created,

                   }).Where(g => g.MemberId == id);

            return result;

        }


    }
}

