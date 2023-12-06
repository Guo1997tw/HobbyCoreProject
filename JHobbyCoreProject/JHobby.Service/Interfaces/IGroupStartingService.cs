using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
	public interface IGroupStartingService
	{
		public IEnumerable<GroupStartingModel> GetGroupStartingAll();

		public IEnumerable<GroupStartingModel?> GetByIdNow(int id);

		public bool UpdateActivityStatus(int id, ActivityStatusModel activityStatusModel);

	}
}
