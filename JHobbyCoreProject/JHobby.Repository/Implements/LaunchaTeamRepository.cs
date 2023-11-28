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

        public IEnumerable<LaunchaTeamDto> GetAll()
        {
			return _jhobbyContext.Activities.Join(
			   _jhobbyContext.ActivityImages,
			   a => a.ActivityId,
			   m => m.ActivityId,
			   (a, m) => new LaunchaTeamDto
			   {
                MemberId = a.MemberId,
                ActivityName = a.ActivityName,
                ActivityStatus = a.ActivityStatus,
                StartTime = a.StartTime,
				Created=a.Created,
				IsCover = m.IsCover,
                ImageName = m.ImageName,
                ActivityImageId = m.ActivityImageId,

            }); 
        }
    }
}
