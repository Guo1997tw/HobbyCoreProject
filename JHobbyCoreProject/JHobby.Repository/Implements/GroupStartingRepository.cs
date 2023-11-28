using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{

	public class GroupStartingRepository : IGroupStartingRepository
	{
		private readonly JhobbyContext _jhobbyContext;

		public GroupStartingRepository(JhobbyContext jhobbyContext)
		{

			_jhobbyContext = jhobbyContext;
		}

		public IEnumerable<GroupStartingDto> GetGroupStartingAll()
		{
			return _jhobbyContext.Activities.Join(
			   _jhobbyContext.ActivityImages,
			   a => a.ActivityId,
			   m => m.ActivityId,
			   (a, m) => new GroupStartingDto
			   {
				   ActivityId = a.ActivityId,
				   ActivityName = a.ActivityName,
				   CurrentPeople = a.CurrentPeople,
				   ActivityStatus = a.ActivityStatus,
				   StartTime = a.StartTime,
				   MaxPeople = a.MaxPeople,
				   IsCover = m.IsCover,
				   ImageName = m.ImageName,
				   ActivityImageId = m.ActivityImageId,

			   });

		}
		public bool Update(int id, GroupStartingDto GroupStartingDto)
		{
			var queryResult = _jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id);

			if (queryResult != null)
			{
				queryResult.CategoryName = GroupStartingDto.ActivityName;

				_jhobbyContext.SaveChanges();

				return true;
			};

			return false;
		}
		public bool Delete(int id)
		{
			var queryResult = _jhobbyContext.Activities.FirstOrDefault(g => g.ActivityId == id);

			if (queryResult == null) { return false; }

			_jhobbyContext.Activities.Remove(queryResult);
			_jhobbyContext.SaveChanges();

			return true;
		}

		public IEnumerable<GroupStartingDto?> GetById(int id)
		{
			var result= _jhobbyContext.Activities.Join(
			   _jhobbyContext.ActivityImages,
			   a => a.ActivityId,
			   m => m.ActivityId,
			   (a, m) => new GroupStartingDto
			   {
				   MemberId = a.MemberId,
				   ActivityId = a.ActivityId,
				   ActivityName = a.ActivityName,
				   CurrentPeople = a.CurrentPeople,
				   ActivityStatus = a.ActivityStatus,
				   StartTime = a.StartTime,
				   MaxPeople = a.MaxPeople,
				   IsCover = m.IsCover,
				   ImageName = m.ImageName,
				   ActivityImageId = m.ActivityImageId,

			   }).Where(g => g.MemberId == id);

			return result;


		}

	}
}
