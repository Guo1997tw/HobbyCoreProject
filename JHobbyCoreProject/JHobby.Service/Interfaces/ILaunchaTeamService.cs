using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;
using JHobby.Service.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
    public interface ILaunchaTeamService
	{
         IEnumerable<LaunchaTeamModel> GetByIdOld(int id);
        

    }
}
