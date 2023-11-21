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
	public class WishRepository : IWishRepository
	{
		private readonly JhobbyContext _jhobbyContext;

		public WishRepository(JhobbyContext jhobbyContext)
		{
			_jhobbyContext = jhobbyContext;
		}

		public IEnumerable<QueryWishDto> GetWishById(int id)
		{
			var queryResult = _jhobbyContext.Wishes.Where(w=>w.MemberId == id).
				Select(w=>new QueryWishDto {
					MemberId = w.MemberId,
					ActivityId = w.ActivityId
				});
			return queryResult;
		}

		public bool Delete(int memberId, int activityId)
		{
			var queryResult = _jhobbyContext.Wishes.FirstOrDefault(
				w => w.MemberId == memberId && w.ActivityId== activityId);

			if (queryResult == null) { return false; }

			_jhobbyContext.Wishes.Remove(queryResult);
			_jhobbyContext.SaveChanges();

			return true;
		}
	}
}
