using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JHobby.Repository.Implements
{
	public class MiddleCenterRepository : IMiddleCenterRepository
	{
		private readonly JhobbyContext _jhobbyContext;

		public MiddleCenterRepository(JhobbyContext jhobbyContext)
		{
			_jhobbyContext = jhobbyContext;
		}
		public IEnumerable<QueryCategoryTypeDto> GetCategoryTypeAll()
		{
			var dtoResult = _jhobbyContext.Activities.Include(a => a.ActivityImages)
			.Join(_jhobbyContext.Members, a => a.MemberId, m => m.MemberId, (a, m) => new QueryCategoryTypeDto
			{
				ActivityId = a.ActivityId,
				MemberId = a.MemberId,
				NickName = m.NickName,
				CategoryId = a.CategoryId,
				CategoryTypeId = a.CategoryTypeId,
				ActivityName = a.ActivityName,
				ActivityStatus = a.ActivityStatus,
				ActivityLocation = a.ActivityLocation,
				ActivityNotes = a.ActivityNotes,
				JoinDeadLine = a.JoinDeadLine,
				ActivityImages = a.ActivityImages
			});
			return dtoResult;
		}
	}
}
