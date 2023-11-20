using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
	public class IndexRepository : IIndexRepository
	{
		private JhobbyContext _JhobbyContext;
		public IndexRepository(JhobbyContext jhobbyContext)
		{
			_JhobbyContext = jhobbyContext;
		}

		public IEnumerable<QueryActivityDto> GetActivityAll()
		{
			var dtoResult = _JhobbyContext.Activities.Include(a => a.ActivityImages)
				.Join(_JhobbyContext.Members,a=>a.MemberId,m=>m.MemberId,(a,m)=>new QueryActivityDto
				{
					ActivityId=a.ActivityId,
					MemberId=a.MemberId,
					MemberName = m.MemberName,
					ActivityName=a.ActivityName,
					ActivityStatus=a.ActivityStatus,
					ActivityLocation=a.ActivityLocation,
					ActivityNotes=a.ActivityNotes,
					JoinDeadLine=a.JoinDeadLine,
					ActivityImages = a.ActivityImages
				});
			return dtoResult;
		}

		public IEnumerable<QueryMemberGenderDto> GetGenderAll()
		{
			var dtoResult = _JhobbyContext.Members.Select(m => new QueryMemberGenderDto
			{
				MemberId = m.MemberId,
				Gender = m.Gender,
				Status = m.Status,
			});

			return dtoResult;
		}

		public IEnumerable<QueryWishDto> GetWishById(int id)
		{
			var dtoResult = _JhobbyContext.Wishes.Select(w => new QueryWishDto {
				MemberId=w.MemberId,
				ActivityId = w.ActivityId
			});
			return dtoResult;
		}
	}
}
