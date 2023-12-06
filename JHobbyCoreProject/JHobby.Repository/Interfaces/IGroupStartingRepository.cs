using JHobby.Repository.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Interfaces
{
	public interface IGroupStartingRepository
	{
		public IEnumerable<GroupStartingDto> GetGroupStartingAll();
		public IEnumerable<GroupStartingDto?> GetByIdNow(int id);
		public bool UpdateActivityStatus(int ActivityId, ActivityStatusDto activityStatusDto);



	}
}
